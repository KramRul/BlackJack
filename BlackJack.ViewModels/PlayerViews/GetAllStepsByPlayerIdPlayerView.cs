using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.ViewModels.PlayerViews
{
    public class GetAllStepsByPlayerIdPlayerView
    {
        public List<PlayerStepGetAllStepsByPlayerIdPlayerViewItem> PlayerSteps { get; set; }

        public GetAllStepsByPlayerIdPlayerView()
        {
            PlayerSteps = new List<PlayerStepGetAllStepsByPlayerIdPlayerViewItem>();
        }
    }

    public class PlayerStepGetAllStepsByPlayerIdPlayerViewItem
    {
        public Guid Id { get; set; }
        public Suite Suite { get; set; }
        public Rank Rank { get; set; }
        public PlayerGetAllStepsByPlayerIdPlayerView Player { get; set; }
        public GameGetAllStepsByPlayerIdPlayerView Game { get; set; }
    }

    public class PlayerGetAllStepsByPlayerIdPlayerView
    {
        public string PlayerId { get; set; }
        public decimal Balance { get; set; }
        public decimal Bet { get; set; }
    }

    public class GameGetAllStepsByPlayerIdPlayerView
    {
        public Guid GameId { get; set; }
        public GameState GameState { get; set; }
    }

}
