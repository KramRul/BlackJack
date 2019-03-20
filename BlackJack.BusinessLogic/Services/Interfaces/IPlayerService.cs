using BlackJack.ViewModels.PlayerViews;
using System.Threading.Tasks;

namespace BlackJack.BusinessLogic.Services.Interfaces
{
    public interface IPlayerService
    {
        Task<GetAllPlayersPlayerView> GetAllPlayers();

        Task<GetAllStepsByPlayerIdPlayerView> GetAllStepsByPlayerId(string playerId);

        Task<GetPlayerByIdPlayerView> GetById(string playerId);
    }
}
