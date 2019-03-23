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
            return await Execute(async () => await _historyService.GetHistoryOfGames());
        }

        [HttpGet]
        [SwaggerResponse(200, "Details of game", typeof(DetailsOfGameHistoryView))]
        [SwaggerResponse(500)]
        public async Task<IActionResult> Game(string gameId)
        {
            return await Execute(async () =>
            {
                var game = await _historyService.GetDetailsByGameId(gameId);
                var model = await _historyService.DetailsOfGame(game);
                return model;
            });
        }
    }
}