namespace EntityFramework.Repositories;

using EntityFramework.DTO;
using EntityFramework.Model;

public interface ICommentRepository
{
    Task<Comment> GetById(Guid guid);
    Task<Comment> Add(Comment comment);
    Task Delete(Guid guid);
    Task<Comment> Update(Guid guid, CommentDto commentDto);
}