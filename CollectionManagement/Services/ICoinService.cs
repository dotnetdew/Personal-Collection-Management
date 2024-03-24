using CollectionManagement.Models;

namespace CollectionManagement.Services
{
    public interface ICoinService : IService<Coin>
    {
        public IEnumerable<Coin> GetCoinsByCollectionId(Guid collectionId);
    }
}