using CollectionManagement.Data;
using CollectionManagement.Models;

namespace CollectionManagement.Repositories
{
    public class PostStampRepository : Repository<PostStamp>, IPostStampRepository
    {
        public PostStampRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}