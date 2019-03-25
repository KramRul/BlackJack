using BlackJack.ViewModels.GameViews;
using BlackJack.ViewModels.HistoryViews;
using System.Threading.Tasks;

namespace BlackJack.BusinessLogic.Services.Interfaces
{
    public interface IHistoryService
    {
        Task<GetHistoryOfGamesHistoryView> GetHistoryOfGames();

        Task<GetDetailsByGameIdHistoryView> GetDetailsByGameId(string gameId);

        Task<DetailsOfGameHistoryView> DetailsOfGame(string gameId);

        Task<GetStepsDetailsOfGameHistoryResponseView> GetStepsDetailsOfGame(
            GetStepsDetailsOfGameHistoryView model);
    }
}
