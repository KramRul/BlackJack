using System;
using System.Collections.Generic;

namespace BlackJack.ViewModels.GameViews
{
    public class GetAllBotsByGameIdGameView
    {
        public List<BotGetAllBotsByGameIdGameViewItem> Bots { get; set; }

        public GetAllBotsByGameIdGameView()
        {
            Bots = new List<BotGetAllBotsByGameIdGameViewItem>();
        }
    }

    public class BotGetAllBotsByGameIdGameViewItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public decimal Bet { get; set; }
    }
}
