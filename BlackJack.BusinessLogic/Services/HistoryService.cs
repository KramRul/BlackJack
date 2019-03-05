using BlackJack.BusinessLogic.Common.Exceptions;
using BlackJack.BusinessLogic.Interfaces.Services;
using BlackJack.DataAccess.Interfaces;
using BlackJack.ViewModels.HistoryViews;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.BusinessLogic.Services
{
    public class HistoryService : BaseService, IHistoryService
    {
        public HistoryService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public async Task<GameDetailsOfGameHistoryView> DetailsOfGame(string gameId)
        {
            var game = await Database.Games.Get(Guid.Parse(gameId));

            if (game == null)
            {
                throw new CustomServiceException("Game does not exist");
            }

            var result = new GameDetailsOfGameHistoryView()
            {
                Id = game.Id,
                GameState = game.GameState,
                WonId = game.WonId,
                Player = new PlayerDetailsOfGameHistoryView()
                {
                    Id = game.PlayerId,
                    UserName = game.Player.UserName,
                    Balance = game.Player.Balance,
                    Bet = game.Player.Bet
                }
            };

            return result;
        }

        public async Task<GetHistoryOfGamesHistoryView> GetHistoryOfGames()
        {
            var result = new GetHistoryOfGamesHistoryView();
            var games = await Database.Games.GetAll();

            foreach (var game in games)
            {
                result.Games.Add(new GameGetHistoryOfGamesHistoryViewItem()
                {
                    Id = game.Id,
                    GameState = game.GameState,
                    Player = new PlayerGetHistoryOfGamesHistoryView()
                    {
                        PlayerId = game.PlayerId,
                        UserName = game.Player.UserName,
                        Balance = game.Player.Balance,
                        Bet = game.Player.Bet
                    }
                });
            }
            return result;
        }
    }
}
