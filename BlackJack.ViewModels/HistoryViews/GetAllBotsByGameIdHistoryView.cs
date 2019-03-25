using System;
using System.Collections.Generic;

namespace BlackJack.ViewModels.HistoryViews
{
    public class GetAllBotsByGameIdHistoryView
    {
        public List<BotGetAllBotsByGameIdHistoryViewItem> Bots { get; set; }

        public GetAllBotsByGameIdHistoryView()
        {
            Bots = new List<BotGetAllBotsByGameIdHistoryViewItem>();
        }
    }

    public class BotGetAllBotsByGameIdHistoryViewItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public decimal Bet { get; set; }
    }
}
