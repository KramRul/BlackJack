using BlackJack.DataAccess.Enums;
using Dapper.Contrib.Extensions;
using System;

namespace BlackJack.DataAccess.Entities
{
    public class PlayerStep
    {
        [ExplicitKey]
        public Guid Id { get; set; }
        public Suite Suite { get; set; }
        public Rank Rank { get; set; }
        public string PlayerId { get; set; }
        [Computed]
        public Player Player { get; set; }
        public Guid GameId { get; set; }
        [Computed]
        public Game Game { get; set; }
    }
}
