using BlackJack.DataAccess.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.ViewModels.GameViews
{
    public class GetDetailsResponseGameView
    {
        public Guid Id { get; set; }
        public int CountOfBots { get; set; }
        public GameState GameState { get; set; }

        public PlayerGetDetailsGameView Player { get; set; }
    }

    public class PlayerGetDetailsGameView
    {
        public string PlayerId { get; set; }
        public string UserName { get; set; }
        public decimal Balance { get; set; }
        public decimal Bet { get; set; }
    }
}
