using BlackJack.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlackJack.DataAccess.Repositories.Interfaces
{
    public interface IBotRepository : IBaseRepository<Bot>
    {
        Task<List<Bot>> GetAllBotsByGameId(Guid gameId);
        Task<int> Count();
    }
}
