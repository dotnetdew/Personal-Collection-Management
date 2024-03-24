using CollectionManagement.Data;
using CollectionManagement.Models;

namespace CollectionManagement.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}