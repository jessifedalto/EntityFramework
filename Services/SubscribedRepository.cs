using EntityFramework.Model;
using EntityFramework.Repositories;

namespace EntityFramework.Services
{
    public class SubscribedRepository(MyStreamingContext ctx) : ISubscribedRepository
    {
        public async Task<Subscribed> Add(Subscribed subscribed)
        {
            await ctx.AddAsync(subscribed);
            await ctx.SaveChangesAsync();
            return subscribed;
        }

        public async Task Delete(Guid guid)
        {
            Subscribed subscribed = await ctx.Subscribeds.FindAsync(guid);

            if (subscribed is null)
                return;

            ctx.Subscribeds.Remove(subscribed);
            await ctx.SaveChangesAsync();
        }

        public async Task<Subscribed> GetById(Guid guid)
        {
            return await ctx.Subscribeds.FindAsync(guid);
        }
    }
}