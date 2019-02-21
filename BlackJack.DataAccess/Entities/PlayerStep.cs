using BlackJack.DataAccess.Enums;
using System;

namespace BlackJack.DataAccess.Entities
{
    public class PlayerStep
    {
        public Guid Id { get; set; }

        public Suite Suite { get; set; }

        public Rank Rank { get; set; }

        public string PlayerId { get; set; }

        public Player Player { get; set; }

        public Guid GameId { get; set; }

        public Game Game { get; set; }
    }
}
