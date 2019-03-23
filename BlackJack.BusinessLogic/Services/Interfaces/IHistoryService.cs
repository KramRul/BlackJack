using BlackJack.ViewModels.GameViews;
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

        Task<GetAllStepsByPlayerIdAndGameIdHistoryView> GetAllStepsByPlayerIdAndGameId(string playerId, Guid gameId);

        Task<GetAllStepOfBotsByGameIdHistoryView> GetAllStepOfBotsByGameId(Guid gameId);

        Task<GetAllBotsByGameIdHistoryView> GetAllBotsByGameId(Guid gameId);

        Task<List<StepPlayerAndBotStepsDetailsOfGameHistoryViewItem>> GetStepsDetailsOfGame(
            GetDetailsByGameIdHistoryView game,
            GetAllStepsByPlayerIdAndGameIdHistoryView playerSteps,
            GetAllStepOfBotsByGameIdHistoryView botsSteps,
            GetAllBotsByGameIdHistoryView bots);
    }
}
