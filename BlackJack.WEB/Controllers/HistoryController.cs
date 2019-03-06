using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlackJack.BusinessLogic.Interfaces.Services;
using BlackJack.ViewModels.GameViews;
using BlackJack.ViewModels.HistoryViews;
using Microsoft.AspNetCore.Mvc;

namespace BlackJack.WEB.Controllers
{
    public class HistoryController : BaseController
    {
        private readonly IHistoryService _historyService;
        private readonly IGameService _gameService;

        public HistoryController(IHistoryService historyService, IGameService gameService)
        {
            _historyService = historyService;
            _gameService = gameService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await Execute(async () =>
            {
                var games = await _historyService.GetHistoryOfGames();
                return games;
            });
            return result;
        }

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