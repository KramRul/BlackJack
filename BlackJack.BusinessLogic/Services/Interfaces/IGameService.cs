﻿using BlackJack.ViewModels.GameViews;
using System;
using System.Threading.Tasks;

namespace BlackJack.BusinessLogic.Services.Interfaces
{
    public interface IGameService
    {
        Task<GetAllStepsByPlayerIdAndGameIdGameView> GetAllStepsByPlayerIdAndGameId(string playerId, Guid gameId);

        Task<GetAllStepOfBotsByGameIdGameView> GetAllStepOfBotsByGameId(Guid gameId);

        Task<StartGameView> Start(string playerName, int countOfBots);

        Task<HitGameView> Hit(string playerId);

        Task PlaceABet(string playerId, decimal bet);

        Task Stand(string playerId);

        Task<GetAllByPlayerIdGameView> GetAllByPlayerId(string playerId);

        Task<GetByIdGameView> GetById(Guid gameId);

        Task<GetDetailsByPlayerIdAndGameIdGameView> GetDetailsByPlayerIdAndGameId(string playerId, Guid gameId);
    }
}
