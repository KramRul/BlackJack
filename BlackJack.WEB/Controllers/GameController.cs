using System;
using System.Threading.Tasks;
using BlackJack.BusinessLogic.Services.Interfaces;
using BlackJack.ViewModels.GameViews;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

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
            return await Execute(() => _playerService.GetAll());
        }

        [HttpGet]
        [Authorize]
        [SwaggerResponse(200, "The game was started", typeof(StartGameView))]
        [SwaggerResponse(500)]
        public async Task<IActionResult> Start(int countOfBots)
        {
            return await Execute(async () =>
            {
                var game = await _gameService.Start(PlayerName, countOfBots);
                return game;
            });
        }

        [HttpGet]
        [Authorize]
        [SwaggerResponse(200, "", typeof(GetDetailsByPlayerIdAndGameIdGameView))]
        [SwaggerResponse(500)]
        public async Task<IActionResult> GetDetails(Guid? gameId)
        {
            return await Execute(async () =>
            {
                if (!gameId.HasValue) gameId = Guid.Empty;
                var model = await _gameService.GetDetailsByPlayerIdAndGameId(PlayerId, (Guid)gameId);
                return model;
            });
        }

        [HttpGet]
        [Authorize]
        [SwaggerResponse(200, "", typeof(HitGameView))]
        [SwaggerResponse(500)]
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
        [SwaggerResponse(200, "", typeof(GetAllStepsByPlayerIdAndGameIdGameView))]
        [SwaggerResponse(500)]
        public async Task<IActionResult> GetAllSteps(string playerId, Guid gameId)
        {
            return await Execute(() => _gameService.GetAllStepsByPlayerIdAndGameId(playerId, gameId));
        }

        [HttpGet]
        [SwaggerResponse(200, "", typeof(GetAllStepOfBotsByGameIdGameView))]
        [SwaggerResponse(500)]
        public async Task<IActionResult> GetAllStepOfBots(Guid gameId)
        {
            return await Execute(() => _gameService.GetAllStepOfBotsByGameId(gameId));
        }

        [HttpGet]
        [SwaggerResponse(200, "", typeof(GetAllByPlayerIdGameView))]
        [SwaggerResponse(500)]
        public async Task<IActionResult> GetGamesByPlayerId(string playerId)
        {
            return await Execute(() => _gameService.GetAllByPlayerId(playerId));
        }

        [HttpGet]
        [SwaggerResponse(200, "", typeof(GetByIdGameView))]
        [SwaggerResponse(500)]
        public async Task<IActionResult> Get(Guid gameId)
        {
            return await Execute(() => _gameService.GetById(gameId));
        }
    }
}