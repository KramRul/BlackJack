using BlackJack.DataAccess.Enums;
using BlackJack.ViewModels.GameViews;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.ViewModels.HistoryViews
{
    public class DetailsOfGameHistoryView
    {
        public GameDetailsOfGameHistoryView Game { get; set; }
        public GetAllStepsGameView PlayerSteps { get; set; }
        public GetAllStepOfBotsGameView BotsSteps { get; set; }
    }

    public class GameDetailsOfGameHistoryView
    {
        public Guid Id { get; set; }

        public GameState GameState { get; set; }

        public PlayerDetailsOfGameHistoryView Player { get; set; }
    }

    public class PlayerDetailsOfGameHistoryView
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public decimal Balance { get; set; }
        public decimal Bet { get; set; }
    }
}
