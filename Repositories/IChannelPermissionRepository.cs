namespace EntityFramework.Repositories;

using EntityFramework.DTO;
using EntityFramework.Model;

public interface IChannelPermissionRepository
{
    Task<ChannelPermission> GetById(Guid guid);
    Task<ChannelPermission> Add(ChannelPermission channelPermission);
    Task Delete(Guid guid);
    Task<ChannelPermission> Update(Guid guid, ChannelPermissionDto channelPermission);
}