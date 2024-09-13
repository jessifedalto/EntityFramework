namespace EntityFramework.Repositories;

using EntityFramework.Model;

public interface IChannelRepository
{
    Task<Channel> GetById(Guid guid);
    Task<Channel> Add(Channel channel);
    Task<Channel> Delete(Channel channel);
    Task<Channel> Delete(Guid guid);
}