using EntityFramework.Model;
using EntityFramework.Repositories;

namespace EntityFramework.Services
{
    public class ContentRepository(MyStreamingContext ctx) : IContentRepository
    {
        public async Task<Content> Add(Content content)
        {
            await ctx.AddAsync(content);
            await ctx.SaveChangesAsync();
            return content;
        }

        public async Task Delete(Guid guid)
        {
            Content content = await ctx.Contents.FindAsync(guid);

            if (content is null)
                return;

            ctx.Contents.Remove(content);
            await ctx.SaveChangesAsync();
        }

        public async Task<Content> GetById(Guid guid)
        {
            return await ctx.Contents.FindAsync(guid);
        }
    }
}