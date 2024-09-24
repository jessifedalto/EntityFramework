namespace EntityFramework.Repositories;

using EntityFramework.DTO;
using EntityFramework.Model;

public interface IPermissionRepository
{
    Task<Permission> GetById(Guid guid);
    Task<Permission> Add(Permission permission);
    Task Delete(Guid guid);
    Task<Permission> Update(Guid guid, PermissionDto channelRole);
}