using BlackJack.ViewModels.EnumViews;
using System;
using System.Collections.Generic;

namespace BlackJack.ViewModels.GameViews
{
    public class GetAllStepOfBotsGameView
    {
        public List<BotStepGetAllStepOfBotsViewItem> BotSteps { get; set; }

        public GetAllStepOfBotsGameView()
        {
            BotSteps = new List<BotStepGetAllStepOfBotsViewItem>();
        }
    }

    public class BotStepGetAllStepOfBotsViewItem
    {
        public Guid Id { get; set; }
        public SuiteTypeEnumView Suite { get; set; }
        public RankTypeEnumView Rank { get; set; }
        public BotGetAllStepOfBotsView Bot { get; set; }
    }

    public class BotGetAllStepOfBotsView
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public decimal Bet { get; set; }
    }
}
