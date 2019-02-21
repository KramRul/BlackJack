using BlackJack.BusinessLogic.Interfaces.Services;
using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Interfaces;
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

        public async Task<GetAllStepsByPlayerIdPlayerView> GetAllStepsByPlayerId(string playerId)
        {
            GetAllStepsByPlayerIdPlayerView pl = new GetAllStepsByPlayerIdPlayerView();
            foreach (var item in await Database.PlayerSteps.GetAll())
            {
                if (item.PlayerId == playerId)
                {
                    pl.PlayerSteps.Add(new PlayerStepGetAllStepsByPlayerIdPlayerViewItem()
                    {
                        Id = item.Id,
                        Player = item.Player,
                        PlayerId = item.PlayerId,
                        Rank = item.Rank,
                        Suite = item.Suite
                    });
                }
            }
            return pl;
        }

        public async Task Edit(EditPlayerView model)
        {
            Player player = await Database.Players.Get(Guid.Parse(model.Id));
            player.UserName = model.UserName;
            Database.Players.Update(player);
            await Database.Save();
        }

        public async Task<GetPlayerByIdPlayerResponseView> GetPlayerById(string playerId)
        {
            var result = await Database.Players.Get(Guid.Parse(playerId));
            GetPlayerByIdPlayerResponseView response = new GetPlayerByIdPlayerResponseView()
            {
                Id = result.Id,
                UserName = result.UserName,
                Balance = result.Balance,
                Bet = result.Bet
            };
            return response;
        }
    }
}
