using BlackJack.ViewModels.HistoryViews;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlackJack.BusinessLogic.Services.Interfaces
{
    public interface IHistoryService
    {
        Task<GetHistoryOfGamesHistoryView> GetHistoryOfGames();

        Task<GetDetailsByGameIdHistoryView> GetDetailsByGameId(string gameId);

        Task<DetailsOfGameHistoryView> DetailsOfGame(GetDetailsByGameIdHistoryView game);

        Task<List<StepPlayerAndBotStepsDetailsOfGameHistoryViewItem>> GetStepsDetailsOfGame(
            GetStepsDetailsOfGameHistoryView model);
    }
}
