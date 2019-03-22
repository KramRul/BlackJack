using BlackJack.ViewModels.EnumViews;
using System;
using System.Collections.Generic;

namespace BlackJack.ViewModels.GameViews
{
    public class GetAllByPlayerIdGameView
    {
        public List<GameGetAllByPlayerIdGameViewItem> Games { get; set; }

        public GetAllByPlayerIdGameView()
        {
            Games = new List<GameGetAllByPlayerIdGameViewItem>();
        }
    }

    public class GameGetAllByPlayerIdGameViewItem
    {
        public Guid Id { get; set; }
        public GameStateTypeEnumView GameState { get; set; }
        public PlayerGetAllByPlayerIdGameView Player { get; set; }
    }

    public class PlayerGetAllByPlayerIdGameView
    {
        public string PlayerId { get; set; }
        public decimal Balance { get; set; }
        public decimal Bet { get; set; }
    }
}
