using BlackJack.ViewModels.GameViews;
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

        Task<GetAllBotsInGameGameView> GetAllBotsInGame(Guid gameId);

        Task<GetAllStepOfBotsGameView> GetAllStepOfBots(Guid gameId);

        Task<StartGameView> Start(string playerName, int countOfBots);

        Task<HitGameView> Hit(string playerId);

        Task PlaceABet(string playerId, decimal bet);

        Task Stand(string playerId);

        Task<GetGamesByPlayerIdGameView> GetGamesByPlayerId(string playerId);

        Task<GetGameView> Get(Guid gameId);

        Task<GetDetailsResponseGameView> GetDetails(string playerId);
    }
}
