using BlackJack.ViewModels.PlayerViews;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.ViewModels.GameViews
{
    public class StartGameResultView
    {
        public StartGameView Game { get; set; }
        public GetAllStepsGameView PlayerSteps { get; set; }
        public GetAllStepOfBotsGameView BotsSteps { get; set; }
    }
}
