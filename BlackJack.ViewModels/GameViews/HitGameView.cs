using BlackJack.ViewModels.EnumViews;
using System;

namespace BlackJack.ViewModels.GameViews
{
    public class HitGameView
    {
        public Guid GameId { get; set; }
        public SuiteTypeEnumView Suite { get; set; }
        public RankTypeEnumView Rank { get; set; }
    }
}
