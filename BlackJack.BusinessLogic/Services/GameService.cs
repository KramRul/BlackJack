using BlackJack.BusinessLogic.Interfaces.Services;
using BlackJack.DataAccess.Interfaces;
using BlackJack.ViewModels.PlayerViews;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.BusinessLogic.Services
{
    public class GameService : BaseService, IGameService
    {
        public GameService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public async Task<GetAllStepsGameView> GetAllSteps(string playerId, Guid gameID)
        {
            GetAllStepsGameView pl = new GetAllStepsGameView();
            foreach (var item in await Database.PlayerSteps.GetAll())
            {
                if (item.PlayerId == playerId && item.GameId == gameID)
                {
                    pl.PlayerSteps.Add(new PlayerStepGetAllStepsGameViewItem()
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
    }
}
