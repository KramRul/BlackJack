using BlackJack.DataAccess.Enums;
using System;

namespace BlackJack.ViewModels.GameViews
{
    public class GetGameView
    {
        public Guid Id { get; set; }
        public GameState GameState { get; set; }
        public PlayerGetGameView Player { get; set; }
    }

    public class PlayerGetGameView
    {
        public string PlayerId { get; set; }
        public decimal Balance { get; set; }
        public decimal Bet { get; set; }
    }
}
