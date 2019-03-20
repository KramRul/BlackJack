using BlackJack.DataAccess.Enums;
using Dapper.Contrib.Extensions;
using System;

namespace BlackJack.DataAccess.Entities
{
    public class PlayerStep : BaseEntity
    {
        public SuiteType Suite { get; set; }
        public RankType Rank { get; set; }
        public string PlayerId { get; set; }
        [Computed]
        public Player Player { get; set; }
        public Guid GameId { get; set; }
        [Computed]
        public Game Game { get; set; }
    }
}
