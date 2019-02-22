using BlackJack.DataAccess.Entities;
using BlackJack.DataAccess.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.ViewModels.GameViews
{
    public class GetAllStepsGameView
    {
        public List<PlayerStepGetAllStepsGameViewItem> PlayerSteps { get; set; }

        public GetAllStepsGameView()
        {
            PlayerSteps = new List<PlayerStepGetAllStepsGameViewItem>();
        }
    }

    public class PlayerStepGetAllStepsGameViewItem
    {
        public Guid Id { get; set; }
        public Suite Suite { get; set; }
        public Rank Rank { get; set; }
        public PlayerGetAllStepsGameView Player { get; set; }
        public GameGetAllStepsGameView Game { get; set; }
    }

    public class PlayerGetAllStepsGameView
    {
        public string PlayerId { get; set; }
        public decimal Balance { get; set; }
        public decimal Bet { get; set; }
    }

    public class GameGetAllStepsGameView
    {
        public Guid GameId { get; set; }
        public GameState GameState { get; set; }
    }
}
