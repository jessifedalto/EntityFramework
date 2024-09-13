using EntityFramework.DTO;
using EntityFramework.Model;

namespace EntityFramework.Repositories;

public interface IUserRepository
{
    Task<User> GetById(Guid guid);
    Task<User> GetUsers();
    Task<User> Add(User user);
    void Delete(Guid guid);
    Task<IEnumerable<Channel>> GetChannels(Guid guid);
    Task<IEnumerable<Playlist>> GetPlaylists(Guid guid);
    Task<IEnumerable<Subscribed>> GetSubscribed(Guid guid);
}