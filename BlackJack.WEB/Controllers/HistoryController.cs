using System.Threading.Tasks;
using BlackJack.BusinessLogic.Services.Interfaces;
using BlackJack.ViewModels.HistoryViews;
using Microsoft.AspNetCore.Mvc;

namespace BlackJack.WEB.Controllers
{
    [Route("/history")]
    public class HistoryController : BaseController
    {
        private readonly IHistoryService _historyService;
        private readonly IGameService _gameService;

        public HistoryController(IHistoryService historyService, IGameService gameService)
        {
            _historyService = historyService;
            _gameService = gameService;
        }

        [HttpGet("index")]
        public async Task<IActionResult> Index()
        {
            var result = await Execute(async () =>
            {
                var games = await _historyService.GetHistoryOfGames();
                return games;
            });
            return result;
        }

        [HttpGet("game")]
        public async Task<IActionResult> Game(string gameId)
        {
            var result = await Execute(async () =>
            {
                var game = await _historyService.DetailsOfGame(gameId);
                var playerSteps = await _gameService.GetAllSteps(game.Player.Id, game.Id);
                var botsSteps = await _gameService.GetAllStepOfBots(game.Id);
                var bots = await _gameService.GetAllBotsInGame(game.Id);
                var steps = await _historyService.GetStepsDetailsOfGame(game, playerSteps, botsSteps, bots);
                var model = new DetailsOfGameHistoryView()
                {
                    Game = game,
                    PlayerSteps = playerSteps,
                    BotsSteps = botsSteps,
                    PlayerAndBotSteps = new PlayerAndBotStepsDetailsOfGameHistoryView()
                    {
                        Steps = steps
                    }
                };
                return model;
            });
            return result;
        }
    }
}