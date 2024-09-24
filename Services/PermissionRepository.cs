using EntityFramework.DTO;
using EntityFramework.Model;
using EntityFramework.Repositories;

namespace EntityFramework.Services
{
    public class PermissionRepository(MyStreamingContext ctx) : IPermissionRepository
    {
        public Task<Permission> Add(Permission permission)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid guid)
        {
            throw new NotImplementedException();
        }

        public Task<Permission> GetById(Guid guid)
        {
            throw new NotImplementedException();
        }

        public Task<Permission> Update(Guid guid, PermissionDto channelRole)
        {
            throw new NotImplementedException();
        }
    }
}