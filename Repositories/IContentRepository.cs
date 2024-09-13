namespace EntityFramework.Repositories;

using EntityFramework.Model;
public interface IContentRepository
{
    Task<Content> GetById(Guid guid);
    Task<Content> Add(Content content);
    Task<Content> Delete(Guid guid);
}