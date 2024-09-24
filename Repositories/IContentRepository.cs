namespace EntityFramework.Repositories;

using EntityFramework.DTO;
using EntityFramework.Model;
public interface IContentRepository
{
    Task<Content> GetById(Guid guid);
    Task<Content> Add(Content content);
    Task Delete(Guid guid);
    Task<Content> Update(Guid guid, ContentDto contentDto);
}