using BlackJack.ViewModels.GameViews;
using BlackJack.ViewModels.HistoryViews;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlackJack.BusinessLogic.Services.Interfaces
{
    public interface IHistoryService
    {
        Task<GetHistoryOfGamesHistoryView> GetHistoryOfGames();

        Task<GetDetailsByGameIdHistoryView> GetDetailsByGameId(string gameId);

        Task<List<StepPlayerAndBotStepsDetailsOfGameHistoryViewItem>> GetStepsDetailsOfGame(
            GetDetailsByGameIdHistoryView game,
            GetAllStepsByPlayerIdAndGameIdGameView playerSteps, 
            GetAllStepOfBotsByGameIdGameView botsSteps,
            GetAllBotsByGameIdGameView bots);
    }
}
