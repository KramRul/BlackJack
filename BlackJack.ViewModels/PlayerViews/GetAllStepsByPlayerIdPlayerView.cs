using BlackJack.ViewModels.EnumViews;
using System;
using System.Collections.Generic;

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
        public SuiteTypeEnumView Suite { get; set; }
        public RankTypeEnumView Rank { get; set; }
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
        public GameStateTypeEnumView GameState { get; set; }
    }

}
