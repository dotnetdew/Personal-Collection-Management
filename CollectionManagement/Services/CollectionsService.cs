using CollectionManagement.Models;
using CollectionManagement.Repositories;

namespace CollectionManagement.Services
{
    public class CollectionsService : Service<MyCollection>, ICollectionsService
    {
        private ICollectionsRepository _collectionsRepository;

        public CollectionsService(ICollectionsRepository repository) : base(repository)
        {
            _collectionsRepository = repository;
        }

        public override void Insert(MyCollection entity)
        {
            entity.Id = Guid.NewGuid();
            base.Insert(entity);
        }

        public IEnumerable<MyCollection> GetCollectionsByUserId(string userId)
            => _collectionsRepository.GetAll().Where(x => x.AppUserId.ToString() == userId);
    }
}