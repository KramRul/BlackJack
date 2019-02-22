﻿using BlackJack.ViewModels.GameViews;
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

        Task<GetAllStepOfBotsGameView> GetAllStepOfBots(Guid gameId);

        Task<StartGameView> Start(string playerId, int countOfBots);

        Task<HitGameView> Hit(string playerId, string gameId);

        Task PlaceABet(string playerId, decimal bet);

        Task Stand(string playerId, Guid gameId);

        Task<GetGamesByPlayerIdGameView> GetGamesByPlayerId(string playerId);

        Task<GetGameView> Get(Guid gameId);
    }
}
