using EntityFramework.DTO;
using EntityFramework.Repositories;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EntityFramework.Services
{
    public class ChannelManagementRepository(MyStreamingContext ctx) : IChannelManagementRepository
    {
        public async Task<ChannelManagement> Add(ChannelManagement channelManagement)
        {
            await ctx.AddAsync(channelManagement);
            await ctx.SaveChangesAsync();
            return channelManagement;
        }

        public async Task Delete(Guid guid)
        {
            ChannelManagement channelManagement = await ctx.ChannelManagements.FindAsync(guid);

            if (channelManagement is not null)
            {
                ctx.ChannelManagements.Remove(channelManagement);
                await ctx.SaveChangesAsync();
            }
        }

        public async Task<ChannelManagement> GetById(Guid guid)
        {
            return await ctx.ChannelManagements.FindAsync(guid);
        }

    }
}