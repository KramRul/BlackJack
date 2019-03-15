using BlackJack.DataAccess.Entities;
using System.Threading.Tasks;

namespace BlackJack.DataAccess.Repositories.Interfaces
{
    public interface IBotRepository : IBaseRepository<Bot>
    {
        Task<int> Count();
    }
}
