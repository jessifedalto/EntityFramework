using EntityFramework.DTO;
using EntityFramework.Repositories;

namespace EntityFramework.Services
{
    public class ChannelManagementRepository(MyStreamingContext ctx) : IChannelManagementRepository
    {
        public Task<ChannelManagement> Add(ChannelManagement channelManagement)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid guid)
        {
            throw new NotImplementedException();
        }

        public Task<ChannelManagement> GetById(Guid guid)
        {
            throw new NotImplementedException();
        }

        public Task<ChannelManagement> Update(Guid guid, ChannelManagementDto channelManagement)
        {
            throw new NotImplementedException();
        }
    }
}