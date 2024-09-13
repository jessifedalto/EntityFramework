using EntityFramework.Model;
using EntityFramework.Repositories;
using Microsoft.EntityFrameworkCore;
public class UserRepository(MyStreamingContext ctx) : IUserRepository
{
    public async Task<User> Add(User user)
    {
      await ctx.AddAsync(user);
      await ctx.SaveChangesAsync();
      return user;
    }

    public async void Delete(Guid guid)
    {
        User user = await ctx.Users.FindAsync(guid);
        ctx.Users.Remove(user);
        await ctx.SaveChangesAsync();
    }

    public async Task<User> GetById(Guid guid)
    {
       return await ctx.Users.FindAsync(guid);
    }

    public async Task<IEnumerable<Channel>> GetChannels(Guid guid)
    {
        var user = await ctx.Users.FindAsync(guid);
        var channels = await ctx.Channels.Where(c => c.Users.Contains(user)).ToListAsync();
        return channels;
    }

    public async Task<IEnumerable<Playlist>> GetPlaylists(Guid guid)
    {
        var user = await ctx.Users.FindAsync(guid);
        var playlists = await ctx.Playlists.Where(p => p.User == user).ToListAsync();
        return playlists;
    }

    public async Task<IEnumerable<Subscribed>> GetSubscribed(Guid guid)
    {
        var user = await ctx.Users.FindAsync(guid);
        var subscribes = await ctx.Subscribeds.Where(s => s.User == user).ToListAsync();
        return subscribes;
    }

    public async Task<User> GetUsers()
        => await ctx.Users.All();
}