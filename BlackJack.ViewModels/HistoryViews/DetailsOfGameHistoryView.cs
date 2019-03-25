using BlackJack.ViewModels.EnumViews;
using System;
using System.Collections.Generic;

namespace BlackJack.ViewModels.HistoryViews
{
    public class DetailsOfGameHistoryView
    {
        public GameDetailsOfGameHistoryView Game { get; set; }
        public PlayerAndBotStepsDetailsOfGameHistoryView PlayerAndBotSteps { get; set; }
    }

    public class GameDetailsOfGameHistoryView
    {
        public Guid Id { get; set; }
        public string WonName { get; set; }
        public GameStateTypeEnumView GameState { get; set; }
        public PlayerDetailsOfGameHistoryView Player { get; set; }
    }

    public class PlayerDetailsOfGameHistoryView
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public decimal Balance { get; set; }
        public decimal Bet { get; set; }
    }
    
    public class PlayerAndBotStepsDetailsOfGameHistoryView
    {
        public List<StepPlayerAndBotStepsDetailsOfGameHistoryViewItem> Steps { get; set; }

        public PlayerAndBotStepsDetailsOfGameHistoryView()
        {
            Steps = new List<StepPlayerAndBotStepsDetailsOfGameHistoryViewItem>();
        }
    }

    public class StepPlayerAndBotStepsDetailsOfGameHistoryViewItem
    {
        public List<CardPlayerAndBotStepsDetailsOfGameHistoryViewItem> Cards { get; set; }

        public StepPlayerAndBotStepsDetailsOfGameHistoryViewItem()
        {
            Cards = new List<CardPlayerAndBotStepsDetailsOfGameHistoryViewItem>();
        }
    }

    public class CardPlayerAndBotStepsDetailsOfGameHistoryViewItem
    {
        public Guid Id { get; set; }
        public SuiteTypeEnumView Suite { get; set; }
        public RankTypeEnumView Rank { get; set; }
        public PlayerCardPlayerAndBotStepsDetailsOfGameHistoryView Player { get; set; }
        public GameCardPlayerAndBotStepsDetailsOfGameHistoryView Game { get; set; }
        public BotCardPlayerAndBotStepsDetailsOfGameHistoryView Bot { get; set; }
    }
    
    public class PlayerCardPlayerAndBotStepsDetailsOfGameHistoryView
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public decimal Balance { get; set; }
        public decimal Bet { get; set; }
    }

    public class GameCardPlayerAndBotStepsDetailsOfGameHistoryView
    {
        public Guid Id { get; set; }
        public string WonName { get; set; }
        public GameStateTypeEnumView GameState { get; set; }
    }

    public class BotCardPlayerAndBotStepsDetailsOfGameHistoryView
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public decimal Bet { get; set; }
    }
}
