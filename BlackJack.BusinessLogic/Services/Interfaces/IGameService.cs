using BlackJack.ViewModels.GameViews;
using System;
using System.Threading.Tasks;

namespace BlackJack.BusinessLogic.Services.Interfaces
{
    public interface IGameService
    {
        Task<GetAllStepsGameView> GetAllStepsByPlayerIdAndGameId(string playerId, Guid gameID);

        Task<GetAllBotsInGameGameView> GetAllBotsByGameId(Guid gameId);

        Task<GetAllStepOfBotsGameView> GetAllStepOfBotsByGameId(Guid gameId);

        Task<StartGameView> Start(string playerName, int countOfBots);

        Task<HitGameView> Hit(string playerId);

        Task PlaceABet(string playerId, decimal bet);

        Task Stand(string playerId);

        Task<GetGamesByPlayerIdGameView> GetGamesByPlayerId(string playerId);

        Task<GetGameView> GetById(Guid gameId);

        Task<GetDetailsGameView> GetDetailsByPlayerIdAndGameId(string playerId, string gameId);

        Task<GetDetailsResponseGameView> GetGameDetailsByPlayerIdAndGameId(string playerId, string gameId);
    }
}
