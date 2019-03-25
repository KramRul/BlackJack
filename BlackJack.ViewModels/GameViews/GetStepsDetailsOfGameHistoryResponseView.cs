using BlackJack.ViewModels.HistoryViews;
using System.Collections.Generic;

namespace BlackJack.ViewModels.GameViews
{
    public class GetStepsDetailsOfGameHistoryResponseView
    {
        public List<StepPlayerAndBotStepsDetailsOfGameHistoryViewItem> PlayerAndBotSteps { get; set; }

        public GetStepsDetailsOfGameHistoryResponseView()
        {
            PlayerAndBotSteps = new List<StepPlayerAndBotStepsDetailsOfGameHistoryViewItem>();
        }
    }
}
