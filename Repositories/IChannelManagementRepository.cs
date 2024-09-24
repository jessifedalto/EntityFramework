namespace EntityFramework.Repositories;

using EntityFramework.DTO;
using EntityFramework.Model;

public interface IChannelManagementRepository
{
    Task<ChannelManagement> GetById(Guid guid);
    Task<ChannelManagement> Add(ChannelManagement channelManagement);
    Task Delete(Guid guid);
    Task<ChannelManagement> Update(Guid guid, ChannelManagementDto channelManagement);
}