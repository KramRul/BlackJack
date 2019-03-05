using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.ViewModels.GameViews
{
    public class GetAllBotsInGameGameView
    {
        public List<BotGetAllBotsInGameGameViewItem> Bots { get; set; }

        public GetAllBotsInGameGameView()
        {
            Bots = new List<BotGetAllBotsInGameGameViewItem>();
        }
    }

    public class BotGetAllBotsInGameGameViewItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public decimal Bet { get; set; }
    }
}
