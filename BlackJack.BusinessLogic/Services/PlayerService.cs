using BlackJack.BusinessLogic.Common.Exceptions;
using BlackJack.BusinessLogic.Services.Interfaces;
using BlackJack.DataAccess.UnitOfWorks.Interfaces;
using BlackJack.ViewModels.EnumViews;
using BlackJack.ViewModels.PlayerViews;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack.BusinessLogic.Services
{
    public class PlayerService : BaseService, IPlayerService
    {
        public PlayerService(IBaseUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public async Task<GetAllPlayersPlayerView> GetAll()
        {
            var result = new GetAllPlayersPlayerView();
            var players = await _database.Players.GetAll();

            result.Players = players.Select(player => new PlayerGetAllPlayersPlayerViewItem()
            {
                PlayerId = player.Id,
                UserName = player.UserName,
                Balance = player.Balance,
                Bet = player.Bet
            }).ToList();
            
            return result;
        }

        public async Task<GetAllStepsByPlayerIdPlayerView> GetAllStepsByPlayerId(string playerId)
        {
            var result = new GetAllStepsByPlayerIdPlayerView();
            var playerSteps = await _database.PlayerSteps.GetAllByPlayerId(playerId);

            result.PlayerSteps = playerSteps.Select(step => new PlayerStepGetAllStepsByPlayerIdPlayerViewItem()
            {
                Id = step.Id,
                Player = new PlayerGetAllStepsByPlayerIdPlayerView()
                {
                    PlayerId = step.PlayerId,
                    Balance = step.Player.Balance,
                    Bet = step.Player.Bet
                },
                Game = new GameGetAllStepsByPlayerIdPlayerView()
                {
                    GameId = step.GameId,
                    GameState = (GameStateTypeEnumView)step.Game.GameState
                },
                Rank = (RankTypeEnumView)step.Rank,
                Suite = (SuiteTypeEnumView)step.Suite
            }).ToList();
            
            return result;
        }

        public async Task<GetByIdPlayerView> GetById(string playerId)
        {
            var player = await _database.Players.Get(Guid.Parse(playerId));
            if (player == null)
            {
                throw new CustomServiceException("Player does not exist");
            }

            var response = new GetByIdPlayerView()
            {
                Id = player.Id,
                UserName = player.UserName,
                Balance = player.Balance,
                Bet = player.Bet
            };
            return response;
        }
    }
}
