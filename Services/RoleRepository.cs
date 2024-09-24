using EntityFramework.DTO;
using EntityFramework.Model;
using EntityFramework.Repositories;

namespace EntityFramework.Services
{
    public class RoleRepository(MyStreamingContext ctx) : IRoleRepository
    {
        public Task<Role> Add(Role role)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid guid)
        {
            throw new NotImplementedException();
        }

        public Task<Role> GetById(Guid guid)
        {
            throw new NotImplementedException();
        }

        public Task<Role> Update(Guid guid, RoleDto roleDto)
        {
            throw new NotImplementedException();
        }
    }
}