namespace EntityFramework.Repositories;

using EntityFramework.DTO;
using EntityFramework.Model;

public interface IChannelRoleRepository
{
    Task<ChannelRole> GetById(Guid guid);
    Task<ChannelRole> Add(ChannelRole channelRole);
    Task Delete(Guid guid);
    Task<ChannelRole> Update(Guid guid, ChannelRoleDto channelRole);
}