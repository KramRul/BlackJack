using System;
using System.Threading.Tasks;
using BlackJack.BusinessLogic.Services.Interfaces;
using BlackJack.ViewModels.GameViews;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlackJack.WEB.Controllers
{
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
                var game = await _gameService.GetDetails(PlayerId);
                var playerSteps = await _gameService.GetAllSteps(PlayerId, game.Id);
                var botsSteps = await _gameService.GetAllStepOfBots(game.Id);
                var model = new GetDetailsGameView()
                {
                    Game = new StartGameView()
                    {
                        Id= game.Id,
                        WonName = game.WonName,
                        Player = new PlayerStartGameView()
                        {
                            PlayerId = game.Player.PlayerId,
                            UserName = game.Player.UserName,
                            Balance = game.Player.Balance,
                            Bet = game.Player.Bet
                        },
                        GameState = game.GameState,
                        CountOfBots = game.CountOfBots
                    },
                    PlayerSteps = playerSteps,
                    BotsSteps = botsSteps
                };
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