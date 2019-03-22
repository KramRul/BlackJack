using System.Threading.Tasks;
using BlackJack.BusinessLogic.Services.Interfaces;
using BlackJack.ViewModels.HistoryViews;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BlackJack.WEB.Controllers
{
    [Route("api/[controller]/[action]")]
    public class HistoryController : BaseController
    {
        private readonly IHistoryService _historyService;
        private readonly IGameService _gameService;

        public HistoryController(IHistoryService historyService, IGameService gameService)
        {
            _historyService = historyService;
            _gameService = gameService;
        }

        [HttpGet]
        [SwaggerResponse(200, "History of games", typeof(GetHistoryOfGamesHistoryView))]
        [SwaggerResponse(500)]
        public async Task<IActionResult> Index()
        {
            var result = await Execute(async () => await _historyService.GetHistoryOfGames());
            return result;
        }

        [HttpGet]
        [SwaggerResponse(200, "Details of game", typeof(DetailsOfGameHistoryView))]
        [SwaggerResponse(500)]
        public async Task<IActionResult> Game(string gameId)
        {
            return await Execute(async () =>
            {
                var game = await _historyService.GetDetailsByGameId(gameId);
                var playerSteps = await _gameService.GetAllStepsByPlayerIdAndGameId(game.Player.Id, game.Id);
                var botsSteps = await _gameService.GetAllStepOfBotsByGameId(game.Id);
                var bots = await _gameService.GetAllBotsByGameId(game.Id);
                var steps = await _historyService.GetStepsDetailsOfGame(game, playerSteps, botsSteps, bots);
                var model = new DetailsOfGameHistoryView()
                {
                    Game = new GameDetailsOfGameHistoryView()
                    {
                        Id = game.Id,
                        WonName = game.WonName,
                        GameState = game.GameState,
                        Player = new PlayerDetailsOfGameHistoryView()
                        {
                            Id = game.Player.Id,
                            UserName = game.Player.UserName,
                            Balance = game.Player.Balance,
                            Bet = game.Player.Bet
                        }
                    },
                    PlayerSteps = playerSteps,
                    BotsSteps = botsSteps,
                    PlayerAndBotSteps = new PlayerAndBotStepsDetailsOfGameHistoryView()
                    {
                        Steps = steps
                    }
                };
                return model;
            });
        }
    }
}