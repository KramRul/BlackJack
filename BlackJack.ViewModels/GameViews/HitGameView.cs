using BlackJack.ViewModels.EnumViews;
using System;

namespace BlackJack.ViewModels.GameViews
{
    public class HitGameView
    {
        public string PlayerId { get; set; }
        public Guid GameId { get; set; }
        public SuiteTypeEnumView Suite { get; set; }
        public RankTypeEnumView Rank { get; set; }
    }
}
