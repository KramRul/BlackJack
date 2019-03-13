using BlackJack.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> GetAllPlayers()
        {
            return await Execute(() => _playerService.GetAllPlayers());
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStepsByPlayerId(string playerId)
        {
            return await Execute(() => _playerService.GetAllStepsByPlayerId(playerId));
        }

        [HttpGet]
        public async Task<IActionResult> GetPlayerById(string playerId)
        {
            return await Execute(() => _playerService.GetPlayerById(playerId));
        }
    }
}