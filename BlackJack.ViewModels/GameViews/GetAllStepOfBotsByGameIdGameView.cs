using BlackJack.ViewModels.EnumViews;
using System;
using System.Collections.Generic;

namespace BlackJack.ViewModels.GameViews
{
    public class GetAllStepOfBotsByGameIdGameView
    {
        public List<BotStepGetAllStepOfBotsByGameIdGameViewItem> BotSteps { get; set; }

        public GetAllStepOfBotsByGameIdGameView()
        {
            BotSteps = new List<BotStepGetAllStepOfBotsByGameIdGameViewItem>();
        }
    }

    public class BotStepGetAllStepOfBotsByGameIdGameViewItem
    {
        public Guid Id { get; set; }
        public SuiteTypeEnumView Suite { get; set; }
        public RankTypeEnumView Rank { get; set; }
        public BotGetAllStepOfBotsByGameIdGameView Bot { get; set; }
    }

    public class BotGetAllStepOfBotsByGameIdGameView
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public decimal Bet { get; set; }
    }
}
