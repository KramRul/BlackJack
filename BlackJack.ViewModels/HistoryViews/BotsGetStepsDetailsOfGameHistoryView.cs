using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.ViewModels.HistoryViews
{
    public class BotsGetStepsDetailsOfGameHistoryView
    {
        public List<BotBotsGetStepsDetailsOfGameHistoryViewItem> Bots { get; set; }

        public BotsGetStepsDetailsOfGameHistoryView()
        {
            Bots = new List<BotBotsGetStepsDetailsOfGameHistoryViewItem>();
        }
    }

    public class BotBotsGetStepsDetailsOfGameHistoryViewItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public decimal Bet { get; set; }
    }
}
