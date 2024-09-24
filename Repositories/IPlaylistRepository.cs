namespace EntityFramework.Repositories;

using EntityFramework.DTO;
using EntityFramework.Model;

public interface IPlaylistRepository
{
    Task<Playlist> GetById(Guid guid);
    Task<Playlist> Add(Playlist playlist);
    Task<IEnumerable<Video>> GetVideos(Guid guid);
    Task Delete(Guid guid);
    Task<Playlist> Update(Guid guid, PlaylistDto playlistDto);
}