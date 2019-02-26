using BlackJack.DataAccess.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.ViewModels.GameViews
{
    public class GetGamesByPlayerIdGameView
    {
        public List<GameGetGamesByPlayerIdGameViewItem> Games { get; set; }

        public GetGamesByPlayerIdGameView()
        {
            Games = new List<GameGetGamesByPlayerIdGameViewItem>();
        }
    }

    public class GameGetGamesByPlayerIdGameViewItem
    {
        public Guid Id { get; set; }

        public GameState GameState { get; set; }

        public PlayerGetAllGamesByPlayerIdGameView Player { get; set; }
    }

    public class PlayerGetAllGamesByPlayerIdGameView
    {
        public string PlayerId { get; set; }
        public decimal Balance { get; set; }
        public decimal Bet { get; set; }
    }
}
