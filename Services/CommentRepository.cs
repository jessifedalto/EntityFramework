using EntityFramework.DTO;
using EntityFramework.Model;
using EntityFramework.Repositories;

namespace EntityFramework.Services
{
    public class CommentRepository(MyStreamingContext ctx) : ICommentRepository
    {
        public async Task<Comment> Add(Comment comment)
        {
            await ctx.AddAsync(comment);
            await ctx.SaveChangesAsync();
            return comment;
        }
        public async Task Delete(Guid guid)
        {
            Comment comment = await ctx.Comments.FindAsync(guid);

            if (comment is null)
                return;

            ctx.Comments.Remove(comment);
            await ctx.SaveChangesAsync();
        }

        public async Task<Comment> GetById(Guid guid)
        {
            return await ctx.Comments.FindAsync(guid);
        }

        public Task<Comment> Update(Guid guid, CommentDto commentDto)
        {
            throw new NotImplementedException();
        }

    }
}