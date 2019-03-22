using BlackJack.ViewModels.PlayerViews;
using System.Threading.Tasks;

namespace BlackJack.BusinessLogic.Services.Interfaces
{
    public interface IPlayerService
    {
        Task<GetAllPlayerView> GetAll();

        Task<GetAllStepsByPlayerIdPlayerView> GetAllStepsByPlayerId(string playerId);

        Task<GetByIdPlayerView> GetById(string playerId);
    }
}
