using EntityFramework.DTO;
using EntityFramework.Model;

namespace EntityFramework.Repositories;

public interface IUserRepository
{
    Task<User> GetById(Guid guid);
    Task<IEnumerable<User>> GetUsers();
    Task<User> Add(User user);
    Task Delete(Guid guid);
    Task Update(Guid guid, UserDto updatedUser);
    Task<IEnumerable<Channel>> GetChannels(Guid guid);
    Task<IEnumerable<Playlist>> GetPlaylists(Guid guid);
    Task<IEnumerable<Subscribed>> GetSubscribed(Guid guid);
}