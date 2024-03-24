using CollectionManagement.Models;
using CollectionManagement.Repositories;

namespace CollectionManagement.Services
{
    public class CoinService : Service<Coin>, ICoinService
    {
        public CoinService(ICoinRepository repository) : base(repository)
        {
        }

        public IEnumerable<Coin> GetCoinsByCollectionId(Guid collectionId)
            => _repository.GetAll().Where(c => c.CollectionId == collectionId);

        public override void Insert(Coin entity)
        {
            entity.Id = Guid.NewGuid();
            base.Insert(entity);
        }
    }
}