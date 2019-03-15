using BlackJack.ViewModels.GameViews;
using System;
using System.Threading.Tasks;

namespace BlackJack.BusinessLogic.Services.Interfaces
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

        Task<GetDetailsGameView> GetDetails(string playerId, string gameId);

        Task<GetDetailsResponseGameView> GetGameDetails(string playerId, string gameId);
    }
}
