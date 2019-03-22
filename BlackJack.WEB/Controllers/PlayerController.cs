using BlackJack.BusinessLogic.Services.Interfaces;
using BlackJack.ViewModels.PlayerViews;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace BlackJack.WEB.Controllers
{
    [Route("api/[controller]/[action]")]
    public class PlayerController : BaseController
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet]
        [SwaggerResponse(200, "", typeof(GetAllPlayerView))]
        [SwaggerResponse(500)]
        public async Task<IActionResult> GetAllPlayers()
        {
            return await Execute(() => _playerService.GetAll());
        }

        [HttpGet]
        [SwaggerResponse(200, "", typeof(GetAllStepsByPlayerIdPlayerView))]
        [SwaggerResponse(500)]
        public async Task<IActionResult> GetAllStepsByPlayerId(string playerId)
        {
            return await Execute(() => _playerService.GetAllStepsByPlayerId(playerId));
        }

        [HttpGet]
        [SwaggerResponse(200, "", typeof(GetByIdPlayerView))]
        [SwaggerResponse(500)]
        public async Task<IActionResult> GetPlayerById(string playerId)
        {
            return await Execute(() => _playerService.GetById(playerId));
        }
    }
}