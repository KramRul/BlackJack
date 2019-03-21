using BlackJack.ViewModels.EnumViews;
using System;

namespace BlackJack.ViewModels.GameViews
{
    public class GetGameDetailsByPlayerIdAndGameIdGameView
    {
        public Guid Id { get; set; }
        public string WonName { get; set; }
        public int CountOfBots { get; set; }
        public GameStateTypeEnumView GameState { get; set; }
        public PlayerGameDetailsByPlayerIdAndGameIdGameView Player { get; set; }
    }

    public class PlayerGameDetailsByPlayerIdAndGameIdGameView
    {
        public string PlayerId { get; set; }
        public string UserName { get; set; }
        public decimal Balance { get; set; }
        public decimal Bet { get; set; }
    }
}
