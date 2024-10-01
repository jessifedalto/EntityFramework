namespace EntityFramework.Repositories;

using EntityFramework.DTO;
using EntityFramework.Model;

public interface IVideoRepository
{
    Task<Video> GetById(Guid guid);
    Task<Video> Add(Video video);
    Task Delete(Guid guid);
    Task<Video> Update(Guid guid, VideoDto videoDto);
    Task ProcessYoutubeVideo(string videoUrl, string videoId);
}