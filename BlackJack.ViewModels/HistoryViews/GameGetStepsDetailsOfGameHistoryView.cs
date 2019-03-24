using BlackJack.ViewModels.EnumViews;
using System;

namespace BlackJack.ViewModels.HistoryViews
{
    public class GameGetStepsDetailsOfGameHistoryView
    {
        public Guid Id { get; set; }
        public string WonName { get; set; }
        public GameStateTypeEnumView GameState { get; set; }
        public PlayerGetStepsDetailsOfGameHistoryView Player { get; set; }
    }

    public class PlayerGetStepsDetailsOfGameHistoryView
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public decimal Balance { get; set; }
        public decimal Bet { get; set; }
    }
}
