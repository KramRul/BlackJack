using BlackJack.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlackJack.WEB.Controllers
{
    [Route("/player")]
    public class PlayerController : BaseController
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet("getAllPlayers")]
        public async Task<IActionResult> GetAllPlayers()
        {
            return await Execute(() => _playerService.GetAllPlayers());
        }

        [HttpGet("getAllStepsByPlayerId")]
        public async Task<IActionResult> GetAllStepsByPlayerId(string playerId)
        {
            return await Execute(() => _playerService.GetAllStepsByPlayerId(playerId));
        }

        [HttpGet("getPlayerById")]
        public async Task<IActionResult> GetPlayerById(string playerId)
        {
            return await Execute(() => _playerService.GetPlayerById(playerId));
        }
    }
}