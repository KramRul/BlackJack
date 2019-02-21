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

        public string PlayerId { get; set; }

        public Player Player { get; set; }

        public Guid GameId { get; set; }

        public Game Game { get; set; }
    }
}
