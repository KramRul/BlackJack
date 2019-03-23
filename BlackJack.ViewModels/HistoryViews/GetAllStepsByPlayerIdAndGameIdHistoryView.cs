using BlackJack.ViewModels.EnumViews;
using System;
using System.Collections.Generic;

namespace BlackJack.ViewModels.HistoryViews
{
    public class GetAllStepsByPlayerIdAndGameIdHistoryView
    {
        public List<PlayerStepGetAllStepsByPlayerIdAndGameIdHistoryViewItem> PlayerSteps { get; set; }

        public GetAllStepsByPlayerIdAndGameIdHistoryView()
        {
            PlayerSteps = new List<PlayerStepGetAllStepsByPlayerIdAndGameIdHistoryViewItem>();
        }
    }

    public class PlayerStepGetAllStepsByPlayerIdAndGameIdHistoryViewItem
    {
        public Guid Id { get; set; }
        public SuiteTypeEnumView Suite { get; set; }
        public RankTypeEnumView Rank { get; set; }
        public PlayerGetAllStepsByPlayerIdAndGameIdHistoryView Player { get; set; }
        public GameGetAllStepsByPlayerIdAndGameIdHistoryView Game { get; set; }
    }

    public class PlayerGetAllStepsByPlayerIdAndGameIdHistoryView
    {
        public string PlayerId { get; set; }
        public string UserName { get; set; }
        public decimal Balance { get; set; }
        public decimal Bet { get; set; }
    }

    public class GameGetAllStepsByPlayerIdAndGameIdHistoryView
    {
        public Guid GameId { get; set; }
        public GameStateTypeEnumView GameState { get; set; }
    }
}
