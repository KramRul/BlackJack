using BlackJack.ViewModels.HistoryViews;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.BusinessLogic.Interfaces.Services
{
    public interface IHistoryService
    {
        Task<GetHistoryOfGamesHistoryView> GetHistoryOfGames();

        Task<GameDetailsOfGameHistoryView> DetailsOfGame(string gameID);
    }
}
