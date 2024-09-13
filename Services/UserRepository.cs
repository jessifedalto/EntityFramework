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

    public async Task Delete(Guid guid)
    {
        User user = await ctx.Users.FindAsync(guid);
        
        if (user is not null)
        {
            ctx.Users.Remove(user);
            await ctx.SaveChangesAsync();
        }
    }

    public async Task<User> GetById(Guid guid)
    {
       return await ctx.Users.FindAsync(guid);
    }

    public async Task<IEnumerable<Channel>> GetChannels(Guid guid)
    {
        var user = await ctx.Users.FindAsync(guid);

        if (user is null)
            return new List<Channel>();

        return await ctx.Channels.Where(c => c.Users.Contains(user)).ToListAsync();
    }

    public async Task<IEnumerable<Playlist>> GetPlaylists(Guid guid)
    {
        var user = await ctx.Users.FindAsync(guid);
          if (user is null)
            return new List<Playlist>();
        
        return await ctx.Playlists.Where(p => p.User == user).ToListAsync();
    }

    public async Task<IEnumerable<Subscribed>> GetSubscribed(Guid guid)
    {
        var user = await ctx.Users.FindAsync(guid);

        if (user is null)
            return new List<Subscribed>();
        
        return await ctx.Subscribeds.Where(s => s.User == user).ToListAsync();
    }

    public async Task<IEnumerable<User>> GetUsers()
        => await ctx.Users.ToListAsync();
}