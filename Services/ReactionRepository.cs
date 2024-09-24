using EntityFramework.DTO;
using EntityFramework.Model;
using EntityFramework.Repositories;

namespace EntityFramework.Services
{
    public class ReactionRepository(MyStreamingContext ctx) : IReactionRepository
    {
        public Task<Reaction> Add(Reaction reaction)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid guid)
        {
            throw new NotImplementedException();
        }

        public Task<Reaction> GetById(Guid guid)
        {
            throw new NotImplementedException();
        }

        public Task<Reaction> Update(Guid guid, ReactionDto reactionDto)
        {
            throw new NotImplementedException();
        }
    }
}