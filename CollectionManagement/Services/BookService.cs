using CollectionManagement.Models;
using CollectionManagement.Repositories;

namespace CollectionManagement.Services
{
    public class BookService : Service<Book>, IBookService
    {
        public BookService(IBookRepository repository) : base(repository)
        {
        }

        public IEnumerable<Book> GetBooksByCollectionId(Guid collectionId)
            => _repository.GetAll().Where(b => b.CollectionId == collectionId);

        public override void Insert(Book entity)
        {
            entity.Id = Guid.NewGuid();
            base.Insert(entity);
        }
    }
}