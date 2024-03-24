using CollectionManagement.Models;
using CollectionManagement.Repositories;

namespace CollectionManagement.Services
{
    public class PostStampService : Service<PostStamp>, IPostStampService
    {
        public PostStampService(IPostStampRepository repository) : base(repository)
        {
        }

        public IEnumerable<PostStamp> GetCoinsByCollectionId(Guid collectionId)
            => _repository.GetAll().Where(p => p.CollectionId == collectionId);
    }
}