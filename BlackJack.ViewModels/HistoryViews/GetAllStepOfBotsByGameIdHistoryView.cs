using BlackJack.ViewModels.EnumViews;
using System;
using System.Collections.Generic;

namespace BlackJack.ViewModels.HistoryViews
{
    public class GetAllStepOfBotsByGameIdHistoryView
    {
        public List<BotStepGetAllStepOfBotsByGameIdHistoryViewItem> BotSteps { get; set; }
        public GetAllStepOfBotsByGameIdHistoryView()
        {
            BotSteps = new List<BotStepGetAllStepOfBotsByGameIdHistoryViewItem>();
        }
    }

    public class BotStepGetAllStepOfBotsByGameIdHistoryViewItem
    {
        public Guid Id { get; set; }
        public SuiteTypeEnumView Suite { get; set; }
        public RankTypeEnumView Rank { get; set; }
        public BotGetAllStepOfBotsByGameIdHistoryView Bot { get; set; }
    }

    public class BotGetAllStepOfBotsByGameIdHistoryView
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public decimal Bet { get; set; }
    }
}
