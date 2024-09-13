namespace EntityFramework.Repositories;

using EntityFramework.Model;

public interface ICommentRepository
{
    Task<Comment> GetById(Guid guid);
    Task<Comment> Add(Comment comment);
    Task<Comment> Delete(Guid guid);
}