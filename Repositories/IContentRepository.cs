namespace EntityFramework.Repositories;

using EntityFramework.Model;
public interface IContentRepository
{
    Task<IEnumerable<Content>> GetContents(Guid videoId);
    Task<Content> GetById(Guid guid);
    Task<Content> Add(Content content);
}