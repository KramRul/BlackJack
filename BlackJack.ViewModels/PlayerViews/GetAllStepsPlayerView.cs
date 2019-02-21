using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.ViewModels.PlayerViews
{
    public class GetAllStepsGameView
    {
        public List<PlayerStepGetAllStepsGameViewItem> PlayerSteps { get; set; }
    }

    public class PlayerStepGetAllStepsGameViewItem
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
