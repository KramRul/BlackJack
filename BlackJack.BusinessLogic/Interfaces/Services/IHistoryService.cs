using BlackJack.ViewModels.GameViews;
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

        Task<List<StepPlayerAndBotStepsDetailsOfGameHistoryViewItem>> GetStepsDetailsOfGame(
            GameDetailsOfGameHistoryView game, 
            GetAllStepsGameView playerSteps, 
            GetAllStepOfBotsGameView botsSteps,
            GetAllBotsInGameGameView bots);
    }
}
