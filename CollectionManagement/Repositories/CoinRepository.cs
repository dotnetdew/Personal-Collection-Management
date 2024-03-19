using CollectionManagement.Data;
using CollectionManagement.Models;
using NuGet.Protocol;

namespace CollectionManagement.Repositories
{
    public class CoinRepository : Repository<Coin>, ICoinRepository
    {
        public CoinRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
