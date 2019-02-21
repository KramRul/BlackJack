using BlackJack.ViewModels.PlayerViews;

namespace BlackJack.BusinessLogic.Interfaces.Services
{
    public interface IPlayerService
    {
        GetAllStepsByPlayerIdPlayerView GetAllStepsByPlayerId(string playerId);

        GetAllStepsPlayerView GetAllSteps(string playerId, string GameID);

        /*void Edit(PlayerViewModel playerVM);

        void Delete(PlayerViewModel playerVM);*/
    }
}
