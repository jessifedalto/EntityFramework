using EntityFramework.Model;

namespace EntityFramework.Repositories;

public interface IUserRepository
{
    Task<User> GetById(Guid guid);
    Task<User> Add(User user);
    Task<User> Delete(User user);
    Task<User> Delete(Guid guid);
}