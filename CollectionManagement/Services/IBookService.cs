using CollectionManagement.Models;

namespace CollectionManagement.Services
{
    public interface IBookService : IService<Book>
    {
        public IEnumerable<Book> GetBooksByCollectionId(Guid collectionId);
    }
}