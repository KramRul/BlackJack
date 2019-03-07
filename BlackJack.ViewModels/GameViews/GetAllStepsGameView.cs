using BlackJack.ViewModels.EnumViews;
using System;
using System.Collections.Generic;

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
        public SuiteTypeEnumView Suite { get; set; }
        public RankTypeEnumView Rank { get; set; }
        public PlayerGetAllStepsGameView Player { get; set; }
        public GameGetAllStepsGameView Game { get; set; }
    }

    public class PlayerGetAllStepsGameView
    {
        public string PlayerId { get; set; }
        public string UserName { get; set; }
        public decimal Balance { get; set; }
        public decimal Bet { get; set; }
    }

    public class GameGetAllStepsGameView
    {
        public Guid GameId { get; set; }
        public GameStateTypeEnumView GameState { get; set; }
    }
}
