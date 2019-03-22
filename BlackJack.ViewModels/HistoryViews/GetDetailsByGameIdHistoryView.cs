using BlackJack.ViewModels.EnumViews;
using System;

namespace BlackJack.ViewModels.HistoryViews
{
    public class GetDetailsByGameIdHistoryView
    {
        public Guid Id { get; set; }
        public string WonName { get; set; }
        public GameStateTypeEnumView GameState { get; set; }
        public PlayerGetDetailsByGameIdHistoryView Player { get; set; }
    }

    public class PlayerGetDetailsByGameIdHistoryView
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public decimal Balance { get; set; }
        public decimal Bet { get; set; }
    }
}
