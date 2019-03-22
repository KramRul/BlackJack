using System.Collections.Generic;

namespace BlackJack.ViewModels.PlayerViews
{
    public class GetAllPlayerView
    {
        public List<PlayerGetAllPlayerViewItem> Players { get; set; }

        public GetAllPlayerView()
        {
            Players = new List<PlayerGetAllPlayerViewItem>();
        }
    }

    public class PlayerGetAllPlayerViewItem
    {
        public string PlayerId { get; set; }
        public string UserName { get; set; }
        public decimal Balance { get; set; }
        public decimal Bet { get; set; }
    }
}
