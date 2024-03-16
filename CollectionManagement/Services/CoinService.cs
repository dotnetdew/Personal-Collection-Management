using CollectionManagement.Models;
using CollectionManagement.Repositories;

namespace CollectionManagement.Services
{
    public class CoinService : Service<Coin>, ICoinService
    {
        public CoinService(IRepository<Coin> repository) : base(repository)
        {
        }
    }
}
