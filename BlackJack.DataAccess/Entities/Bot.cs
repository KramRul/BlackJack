using Dapper.Contrib.Extensions;
using System;

namespace BlackJack.DataAccess.Entities
{
    public class Bot
    {
        [ExplicitKey]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public decimal Bet { get; set; }
    }
}
