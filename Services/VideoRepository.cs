using EntityFramework.DTO;
using EntityFramework.Model;
using EntityFramework.Repositories;

namespace EntityFramework.Services
{
    public class VideoRepository(MyStreamingContext ctx) : IVideoRepository
    {
        public Task<Video> Add(Video video)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid guid)
        {
            throw new NotImplementedException();
        }

        public Task<Video> GetById(Guid guid)
        {
            throw new NotImplementedException();
        }

        public Task<Video> Update(Guid guid, VideoDto videoDto)
        {
            throw new NotImplementedException();
        }
    }
}