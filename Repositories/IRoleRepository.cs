namespace EntityFramework.Repositories;

using EntityFramework.DTO;
using EntityFramework.Model;

public interface IRoleRepository
{
    Task<Role> GetById(Guid guid);
    Task<Role> Add(Role role);
    Task Delete(Guid guid);
    Task<Role> Update(Guid guid, RoleDto roleDto);
}