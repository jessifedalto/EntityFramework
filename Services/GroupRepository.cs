using EntityFramework.DTO;
using EntityFramework.Model;
using EntityFramework.Repositories;

namespace EntityFramework.Services
{
    public class GroupRepository(MyStreamingContext ctx) : IGroupRepository
    {
        public Task<Group> Add(Group group)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid guid)
        {
            throw new NotImplementedException();
        }

        public Task<Group> GetById(Guid guid)
        {
            throw new NotImplementedException();
        }

        public Task<Group> Update(Guid guid, GroupDto groupDto)
        {
            throw new NotImplementedException();
        }
    }
}