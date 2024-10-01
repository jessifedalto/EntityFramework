using System.Diagnostics;
using EntityFramework.DTO;
using EntityFramework.Model;
using EntityFramework.Repositories;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

namespace EntityFramework.Services
{
    public class VideoRepository(MyStreamingContext ctx) : IVideoRepository
    {
        public async Task<Video> Add(Video video)
        {
            await ctx.AddAsync(video);
            await ctx.SaveChangesAsync();
            return video;
        }

        public Task Delete(Guid guid)
        {
            throw new NotImplementedException();
        }

        public Task<Video> GetById(Guid guid)
        {
            throw new NotImplementedException();
        }

        public Task<Video> Update(Guid guid, VideoDto videoDto)
        {
            throw new NotImplementedException();
        }
        public async Task ProcessYoutubeVideo(string videoUrl, string videoId)
        {
            YoutubeClient youtube = new();
            var video = await youtube.Videos.GetAsync(videoId);
            var streamManifest = await youtube.Videos.Streams.GetManifestAsync(videoId);

            if (streamManifest == null)
            {
                Console.WriteLine("Manifesto de stream não encontrado.");
                return;
            }

            var streamInfo = streamManifest.GetMuxedStreams().GetWithHighestBitrate();
            System.Console.WriteLine(streamInfo);
            if (streamInfo.Url == null)
            {
                Console.WriteLine("Nenhum stream disponível.");
                return;
            }

            var videoFilePath = Path.Combine(Path.GetTempPath(), $"{videoUrl}.mp4");

            Video video1 = new Video
            {
                VideoName = video.Title
            };

            await Add(video1);

            await youtube.Videos.Streams.DownloadAsync(streamInfo, videoFilePath);

            var hlsDirectory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(hlsDirectory);
            var playlistPath = Path.Combine(hlsDirectory, "playlist.m3u8");

            var processStartInfo = new ProcessStartInfo
            {
                FileName = "ffmpeg",
                Arguments = $"-i \"{videoFilePath}\" -hls_time 10 -hls_list_size 0 -f hls \"{playlistPath}\"",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (var process = Process.Start(processStartInfo)!)
            {
                var error = await process.StandardError.ReadToEndAsync();
                process.WaitForExit();

                if (process.ExitCode != 0)
                {
                    Console.WriteLine($"Erro ao processar o vídeo: {error}");
                    return;
                }
            }

            var m3u8Lines = System.IO.File.ReadAllLines(playlistPath);
            foreach (var line in m3u8Lines)
            {
                if (line.EndsWith(".ts"))
                {
                    var tsFilePath = Path.Combine(hlsDirectory, line.Trim());

                    if (System.IO.File.Exists(tsFilePath))
                    {
                        var content = new Content
                        {
                            Piece = System.IO.File.ReadAllBytes(tsFilePath)
                        };
                        await ctx.Contents.AddAsync(content);
                    }
                }
            }

            System.IO.File.Delete(videoFilePath);
            Directory.Delete(hlsDirectory, true);
        }
    }
}