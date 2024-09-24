namespace EntityFramework.Repositories;

using EntityFramework.DTO;
using EntityFramework.Model;

public interface IGroupRepository
{
    Task<Group> GetById(Guid guid);
    Task<Group> Add(Group group);
    Task Delete(Guid guid);
    Task<Group> Update(Guid guid, GroupDto groupDto);
}