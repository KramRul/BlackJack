﻿using System;
using System.Threading.Tasks;
using BlackJack.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlackJack.WEB.Controllers
{
    [Route("api/[controller]/[action]")]
    public class GameController : BaseController
    {
        private readonly IPlayerService _playerService;
        private readonly IGameService _gameService;
        private readonly IAccountService _accountService;

        public GameController(IPlayerService playerService, IGameService gameService, IAccountService accountService)
        {
            _playerService = playerService;
            _gameService = gameService;
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await Execute(() => _playerService.GetAllPlayers());
            return result;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Start(int countOfBots, string playerName)
        {
            var result = await Execute(async () =>
            {
                var game = await _gameService.Start(playerName, countOfBots);
                return game;
            });
            return result;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetDetails()
        {
            var result = await Execute(async () =>
            {
                var model = await _gameService.GetDetails(PlayerId);              
                return model;
            });
            return result;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Hit()
        {
            return await Execute(() => _gameService.Hit(PlayerId));
        }

        [HttpGet]
        public async Task<IActionResult> PlaceABet(decimal bet)
        {
            return await Execute(() => _gameService.PlaceABet(PlayerId, bet));
        }

        [HttpGet]
        public async Task<IActionResult> Stand()
        {
            return await Execute(() => _gameService.Stand(PlayerId));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSteps(string playerId, Guid gameId)
        {
            return await Execute(() => _gameService.GetAllSteps(playerId, gameId));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStepOfBots(Guid gameId)
        {
            return await Execute(() => _gameService.GetAllStepOfBots(gameId));
        }

        [HttpGet]
        public async Task<IActionResult> GetGamesByPlayerId(string playerId)
        {
            return await Execute(() => _gameService.GetGamesByPlayerId(playerId));
        }

        [HttpGet]
        public async Task<IActionResult> Get(Guid gameId)
        {
            return await Execute(() => _gameService.Get(gameId));
        }
    }
}