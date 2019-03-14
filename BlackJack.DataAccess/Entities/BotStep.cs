using BlackJack.DataAccess.Enums;
using Dapper.Contrib.Extensions;
using System;

namespace BlackJack.DataAccess.Entities
{
    public class BotStep
    {
        [ExplicitKey]
        public Guid Id { get; set; }
        public Suite Suite { get; set; }
        public Rank Rank { get; set; }
        public Guid BotId { get; set; }
        [Computed]
        public Bot Bot { get; set; }
        public Guid GameId { get; set; }
        [Computed]
        public Game Game { get; set; }
    }
}
