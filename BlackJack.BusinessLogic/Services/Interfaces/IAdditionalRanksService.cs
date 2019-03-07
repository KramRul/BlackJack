using BlackJack.DataAccess.Enums;
using System.Collections.Generic;

namespace BlackJack.BusinessLogic.Services.Interfaces
{
    public interface IAdditionalRanksService
    {
        int TotalValue(IEnumerable<Rank> steps);
    }
}
