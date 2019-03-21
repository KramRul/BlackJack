using BlackJack.ViewModels.EnumViews;
using System;

namespace BlackJack.ViewModels.GameViews
{
    public class GetByIdGameView
    {
        public Guid Id { get; set; }
        public GameStateTypeEnumView GameState { get; set; }
        public PlayerGetByIdGameView Player { get; set; }
    }

    public class PlayerGetByIdGameView
    {
        public string PlayerId { get; set; }
        public decimal Balance { get; set; }
        public decimal Bet { get; set; }
    }
}
