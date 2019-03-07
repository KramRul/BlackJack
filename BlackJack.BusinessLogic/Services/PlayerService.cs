using BlackJack.BusinessLogic.Common.Exceptions;
using BlackJack.BusinessLogic.Services.Interfaces;
using BlackJack.DataAccess.Interfaces;
using BlackJack.ViewModels.EnumViews;
using BlackJack.ViewModels.PlayerViews;
using System;
using System.Threading.Tasks;

namespace BlackJack.BusinessLogic.Services
{
    public class PlayerService : BaseService, IPlayerService
    {
        public PlayerService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public async Task<GetAllPlayersPlayerView> GetAllPlayers()
        {
            var result = new GetAllPlayersPlayerView();
            var players = await Database.Players.GetAll();
            foreach (var player in players)
            {
                result.Players.Add(new PlayerGetAllPlayersPlayerViewItem()
                {
                    PlayerId = player.Id,
                    UserName = player.UserName,
                    Balance = player.Balance,
                    Bet = player.Bet
                });
            };
            return result;
        }

        public async Task<GetAllStepsByPlayerIdPlayerView> GetAllStepsByPlayerId(string playerId)
        {
            var result = new GetAllStepsByPlayerIdPlayerView();
            foreach (var item in await Database.PlayerSteps.GetAll())
            {
                if (item.PlayerId == playerId)
                {
                    result.PlayerSteps.Add(new PlayerStepGetAllStepsByPlayerIdPlayerViewItem()
                    {
                        Id = item.Id,
                        Player = new PlayerGetAllStepsByPlayerIdPlayerView()
                        {
                            PlayerId = item.PlayerId,
                            Balance = item.Player.Balance,
                            Bet = item.Player.Bet
                        },
                        Game = new GameGetAllStepsByPlayerIdPlayerView()
                        {
                            GameId = item.GameId,
                            GameState = (GameStateTypeEnumView)item.Game.GameState
                        },
                        Rank = (RankTypeEnumView)item.Rank,
                        Suite = (SuiteTypeEnumView)item.Suite
                    });
                }
            }
            return result;
        }

        public async Task<GetPlayerByIdPlayerView> GetPlayerById(string playerId)
        {
            var player = await Database.Players.Get(Guid.Parse(playerId));
            if (player == null)
            {
                throw new CustomServiceException("Player does not exist");
            }

            var response = new GetPlayerByIdPlayerView()
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
