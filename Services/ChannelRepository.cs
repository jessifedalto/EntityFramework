using EntityFramework.DTO;
using EntityFramework.Model;
using EntityFramework.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Services
{
    public class ChannelRepository(MyStreamingContext ctx) : IChannelRepository
    {
        public async Task<Channel> Add(Channel channel)
        {
            await ctx.AddAsync(channel);
            await ctx.SaveChangesAsync();
            return channel;
        }

        public async Task Delete(Guid guid)
        {
            Channel channel = await ctx.Channels.FindAsync(guid);

            if (channel is null)
                return;

            ctx.Channels.Remove(channel);
            await ctx.SaveChangesAsync();
        }

        public async Task<Channel> GetById(Guid guid)
        {
            return await ctx.Channels.FindAsync(guid);
        }

        public async Task<IEnumerable<User>> GetUsers(Guid guid)
        {
            var channel = await ctx.Channels.FindAsync(guid);

            if (channel is null)
                return [];

            return await ctx.Users.Where(u => u.Channels.Contains(channel)).ToListAsync();
        }

        public async Task<IEnumerable<Video>> GetVideos(Guid guid)
        {
            var channel = await ctx.Channels.FindAsync(guid);

            if (channel is null)
                return [];

            return await ctx.Videos.Where(v => v.ChannelId.Equals(guid)).ToListAsync();
        }

        public Task<Channel> Update(Guid guid, ChannelDto channel)
        {
            throw new NotImplementedException();
        }

        public async Task<Channel> AddUser(Channel channel, User user)
        {
            if (channel.Users == null || channel.Users.Count == 0)
                channel.Users = [];

            channel.Users.Add(user);

            ctx.Channels.Update(channel);
            await ctx.SaveChangesAsync();

            return channel;
        }

        public async Task<Channel> AddVideo(Channel channel, Video video)
        {
            channel.Videos.Add(video);

            ctx.Channels.Update(channel);

            await ctx.SaveChangesAsync();

            return channel;
        }

        public async Task<IEnumerable<Channel>>GetChannels()
        {
            return await ctx.Channels.ToListAsync();
        }
    }
}