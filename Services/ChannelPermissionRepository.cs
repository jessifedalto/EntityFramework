using EntityFramework.DTO;
using EntityFramework.Model;
using EntityFramework.Repositories;

namespace EntityFramework.Services
{
    public class ChannelPermissionRepository(MyStreamingContext ctx) : IChannelPermissionRepository
    {
        public Task<ChannelPermission> Add(ChannelPermission channelPermission)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid guid)
        {
            throw new NotImplementedException();
        }

        public Task<ChannelPermission> GetById(Guid guid)
        {
            throw new NotImplementedException();
        }

        public Task<ChannelPermission> Update(Guid guid, ChannelPermissionDto channelPermission)
        {
            throw new NotImplementedException();
        }
    }
}