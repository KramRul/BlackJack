using BlackJack.ViewModels.GameViews;
using BlackJack.ViewModels.HistoryViews;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlackJack.BusinessLogic.Services.Interfaces
{
    public interface IHistoryService
    {
        Task<GetHistoryOfGamesHistoryView> GetHistoryOfGames();

        Task<GameDetailsOfGameHistoryView> DetailsOfGame(string gameID);

        Task<List<StepPlayerAndBotStepsDetailsOfGameHistoryViewItem>> GetStepsDetailsOfGame(
            GameDetailsOfGameHistoryView game,
            GetAllStepsByPlayerIdAndGameIdGameView playerSteps, 
            GetAllStepOfBotsByGameIdGameView botsSteps,
            GetAllBotsByGameIdGameView bots);
    }
}
