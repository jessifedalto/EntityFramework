namespace EntityFramework.Repositories;

using EntityFramework.Model;

public interface IPlaylistRepository
{
    Task<Playlist> GetById(Guid guid);
    Task<Playlist> Add(Playlist playlist);
    Task<Video> GetVideos(Guid guid);
    Task<Playlist> Delete(Guid guid);
}