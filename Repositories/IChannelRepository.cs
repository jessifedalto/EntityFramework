namespace EntityFramework.Repositories;

using EntityFramework.Model;

public interface IChannelRepository
{
    Task<Channel> GetById(Guid guid);
    Task<Channel> Add(Channel channel);
    Task Delete(Guid guid);
    Task<IEnumerable<User>> GetUsers(Guid guid);
    Task<IEnumerable<Video>> GetVideos(Guid guid);
}