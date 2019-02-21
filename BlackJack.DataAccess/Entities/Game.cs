using BlackJack.DataAccess.Enums;
using System;

namespace BlackJack.DataAccess.Entities
{
    public class Game
    {
        public Guid Id { get; set; }

        public GameState GameState { get; set; }

        public Player Player { get; set; }
    }
}
