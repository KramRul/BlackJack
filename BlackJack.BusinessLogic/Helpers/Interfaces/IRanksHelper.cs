using BlackJack.DataAccess.Enums;
using System.Collections.Generic;

namespace BlackJack.BusinessLogic.Helpers.Interfaces
{
    public interface IRanksHelper
    {
        int TotalValue(IEnumerable<Rank> steps);
    }
}
