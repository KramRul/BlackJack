using BlackJack.ViewModels.EnumViews;
using System;
using System.Collections.Generic;

namespace BlackJack.ViewModels.GameViews
{
    public class GetAllStepsByPlayerIdAndGameIdGameView
    {
        public List<PlayerStepGetAllStepsByPlayerIdAndGameIdGameViewItem> PlayerSteps { get; set; }

        public GetAllStepsByPlayerIdAndGameIdGameView()
        {
            PlayerSteps = new List<PlayerStepGetAllStepsByPlayerIdAndGameIdGameViewItem>();
        }
    }

    public class PlayerStepGetAllStepsByPlayerIdAndGameIdGameViewItem
    {
        public Guid Id { get; set; }
        public SuiteTypeEnumView Suite { get; set; }
        public RankTypeEnumView Rank { get; set; }
        public PlayerGetAllStepsByPlayerIdAndGameIdGameView Player { get; set; }
        public GameGetAllStepsByPlayerIdAndGameIdGameView Game { get; set; }
    }

    public class PlayerGetAllStepsByPlayerIdAndGameIdGameView
    {
        public string PlayerId { get; set; }
        public string UserName { get; set; }
        public decimal Balance { get; set; }
        public decimal Bet { get; set; }
    }

    public class GameGetAllStepsByPlayerIdAndGameIdGameView
    {
        public Guid GameId { get; set; }
        public GameStateTypeEnumView GameState { get; set; }
    }
}
