using CollectionManagement.Models;

namespace CollectionManagement.Services
{
    public interface ICollectionsService : IService<MyCollection>
    {
        public IEnumerable<MyCollection> GetCollectionsByUserId(string id);
    }
}