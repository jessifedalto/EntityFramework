namespace EntityFramework.Repositories;

using EntityFramework.Model;

public interface ISubscribedRepository
{
    Task<Subscribed> GetById(Guid guid);
    Task<Subscribed> Add(Subscribed subscribed);
    Task Delete(Guid guid);
}