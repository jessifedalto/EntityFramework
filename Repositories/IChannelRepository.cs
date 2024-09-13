namespace EntityFramework.Repositories;

using EntityFramework.Model;

public interface IChannelRepository
{
    Task<Channel> GetById(Guid guid);
    Task<Channel> Add(Channel channel);
    Task<Channel> Delete(Guid guid);
    Task<User> GetUsers(Guid guid);
    Task<Video> GetVideos(Guid guid);
}