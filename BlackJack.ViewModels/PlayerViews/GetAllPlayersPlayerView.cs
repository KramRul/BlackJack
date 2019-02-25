using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.ViewModels.PlayerViews
{
    public class GetAllPlayersPlayerView
    {
        public List<PlayerGetAllPlayersPlayerViewItem> Players { get; set; }

        public GetAllPlayersPlayerView()
        {
            Players = new List<PlayerGetAllPlayersPlayerViewItem>();
        }
    }

    public class PlayerGetAllPlayersPlayerViewItem
    {
        public string PlayerId { get; set; }
        public string UserName { get; set; }
        public decimal Balance { get; set; }
        public decimal Bet { get; set; }
    }
}
