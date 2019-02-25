﻿using System;
using System.Threading.Tasks;
using BlackJack.BusinessLogic.Interfaces.Services;
using BlackJack.DataAccess.Entities;
using BlackJack.ViewModels.GameViews;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlackJack.WEB.Controllers
{
    public class GameController : BaseController
    {
        private readonly IPlayerService _playerService;
        private readonly IGameService _gameService;

        public GameController(IPlayerService playerService, IGameService gameService)
        {
            _playerService = playerService;
            _gameService = gameService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await Execute(() => _playerService.GetAllPlayers());
            return result;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Start(int countOfBots, string playerId)
        {
            var result = await Execute(async () =>
            {
                var game = await _gameService.Start(playerId, countOfBots);
                var playerSteps = await _gameService.GetAllSteps(playerId, game.Id);
                var botsSteps = await _gameService.GetAllStepOfBots(game.Id);
                var model = new StartGameResultView()
                {
                    Game = game,
                    PlayerSteps = playerSteps,
                    BotsSteps = botsSteps
                };
                return model;
            });
            return result;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Hit(string playerId, string gameId)
        {
            return await Execute(() => _gameService.Hit(playerId, gameId));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PlaceABet(string playerId, decimal bet)
        {
            return await Execute(() => _gameService.PlaceABet(playerId, bet));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Stand(string playerId, Guid gameId)
        {
            return await Execute(() => _gameService.Stand(playerId, gameId));
        }
    }
}