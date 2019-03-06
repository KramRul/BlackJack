using BlackJack.DataAccess.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.ViewModels.HistoryViews
{
    public class GetHistoryOfGamesHistoryView
    {
        public List<GameGetHistoryOfGamesHistoryViewItem> Games { get; set; }

        public GetHistoryOfGamesHistoryView()
        {
            Games = new List<GameGetHistoryOfGamesHistoryViewItem>();
        }
    }

    public class GameGetHistoryOfGamesHistoryViewItem
    {
        public Guid Id { get; set; }
        public string WonName { get; set; }
        public GameState GameState { get; set; }

        public PlayerGetHistoryOfGamesHistoryView Player { get; set; }
    }

    public class PlayerGetHistoryOfGamesHistoryView
    {
        public string PlayerId { get; set; }
        public string UserName { get; set; }
        public decimal Balance { get; set; }
        public decimal Bet { get; set; }
    }
}
