using CollectionManagement.Data;
using CollectionManagement.Models;

namespace CollectionManagement.Repositories
{
    public class CollectionsRepository : Repository<MyCollection>, ICollectionsRepository
    {
        public CollectionsRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
