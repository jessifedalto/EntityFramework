namespace EntityFramework.Repositories;

using EntityFramework.DTO;
using EntityFramework.Model;

public interface IReactionRepository
{
    Task<Reaction> GetById(Guid guid);
    Task<Reaction> Add(Reaction reaction);
    Task Delete(Guid guid);
    Task<Reaction> Update(Guid guid, ReactionDto reactionDto);
}