using EntityFramework.DTO;
using EntityFramework.Model;
using EntityFramework.Repositories;

namespace EntityFramework.Services
{
    public class ChannelRoleRepository(MyStreamingContext ctx) : IChannelRoleRepository
    {
        public Task<ChannelRole> Add(ChannelRole channelRole)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid guid)
        {
            throw new NotImplementedException();
        }

        public Task<ChannelRole> GetById(Guid guid)
        {
            throw new NotImplementedException();
        }

        public Task<ChannelRole> Update(Guid guid, ChannelRoleDto channelRole)
        {
            throw new NotImplementedException();
        }
    }
}