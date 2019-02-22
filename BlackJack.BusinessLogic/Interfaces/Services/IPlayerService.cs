using BlackJack.ViewModels.PlayerViews;
using System;
using System.Threading.Tasks;

namespace BlackJack.BusinessLogic.Interfaces.Services
{
    public interface IPlayerService
    {
        Task<GetAllStepsByPlayerIdPlayerView> GetAllStepsByPlayerId(string playerId);

        Task<GetPlayerByIdPlayerView> GetPlayerById(string playerId);
    }
}
