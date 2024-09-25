namespace EntityFramework.Repositories;

using EntityFramework.DTO;

public interface IChannelManagementRepository
{
    Task<ChannelManagement> GetById(Guid guid);
    Task<ChannelManagement> Add(ChannelManagement channelManagement);
    Task Delete(Guid guid);
}