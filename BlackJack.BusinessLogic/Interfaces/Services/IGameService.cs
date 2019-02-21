using BlackJack.ViewModels.PlayerViews;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.BusinessLogic.Interfaces.Services
{
    public interface IGameService
    {
        Task<GetAllStepsGameView> GetAllSteps(string playerId, Guid gameID);

        /*GameViewModel StartGame(string playerId, int countOfBots);

        PlayerStepViewModel Hit(string playerId, string gameId);

        void PlaceABet(string playerId, decimal bet);

        void Stand(string playerId, string gameId);

        IEnumerable<GameViewModel> GetGamesForPlayer(string playerId)

        GameViewModel GetGame(Guid gameId)*/
    }
}
