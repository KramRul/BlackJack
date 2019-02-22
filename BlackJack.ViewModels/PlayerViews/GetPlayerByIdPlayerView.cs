using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.ViewModels.PlayerViews
{
    public class GetPlayerByIdPlayerView
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public decimal Balance { get; set; }

        public decimal Bet { get; set; }
    }
}
