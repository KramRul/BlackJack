using BlackJack.DataAccess.Enums;
using System;

namespace BlackJack.ViewModels.GameViews
{
    public class HitGameView
    {
        public string PlayerId { get; set; }
        public Guid GameId { get; set; }
        public Suite Suite { get; set; }
        public Rank Rank { get; set; }
    }
}
