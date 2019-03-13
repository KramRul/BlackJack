using BlackJack.DataAccess.Entities;
using System.Threading.Tasks;

namespace BlackJack.DataAccess.Interfaces
{
    public interface IBotRepository: IBaseRepository<Bot>
    {
        Task<int> Count();
    }
}
