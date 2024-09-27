using System.Diagnostics;
using EntityFramework.Model;
using System.IO;    
using EntityFramework.Repositories;
using Microsoft.AspNetCore.Mvc;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;
using Microsoft.AspNetCore.Cors;

namespace EntityFramework.Controllers;
[ApiController]
[Route("video")]
 [EnableCors("main")]
public class VideoController(IVideoRepository videoRepo, YoutubeClient youtube, IContentRepository contentRepo) : ControllerBase
{
    [HttpPost("{id}")]
    public async Task<IActionResult> UploadContent(string id)
    {
        string url = $"www.youtube.com/watch?v={id}";
        if (string.IsNullOrWhiteSpace(url))
            return BadRequest("URL do vídeo é inválida.");

        await ProcessYoutubeVideo(url, id);
        return Ok("Vídeo processado e armazenado com sucesso.");
    }
    public async Task ProcessYoutubeVideo(string videoUrl, string videoId)
    {
        var video = await youtube.Videos.GetAsync(videoId);
        var streamManifest = await youtube.Videos.Streams.GetManifestAsync(videoId);
        var streamInfo = streamManifest.GetMuxedStreams().GetWithHighestBitrate();

        var videoFilePath = Path.Combine(Path.GetTempPath(), $"{videoUrl}.mp4");

        Video video1 = new Video
        {
            VideoName = video.Title
        };

        await videoRepo.Add(video1);

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
                    await contentRepo.Add(content);
                }
            }
        }

        System.IO.File.Delete(videoFilePath);
        Directory.Delete(hlsDirectory, true);
    }
}