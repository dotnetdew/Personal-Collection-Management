using CollectionManagement.Models;

namespace CollectionManagement.Services
{
    public interface IPostStampService : IService<PostStamp>
    {
        public IEnumerable<PostStamp> GetCoinsByCollectionId(Guid collectionId);
    }
}