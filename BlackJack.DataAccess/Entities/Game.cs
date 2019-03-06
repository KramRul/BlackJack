using BlackJack.DataAccess.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlackJack.DataAccess.Entities
{
    public class Game
    {
        public Guid Id { get; set; }

        public GameState GameState { get; set; }

        public string WonName { get; set; }

        public string PlayerId { get; set; }
        [ForeignKey("PlayerId")]
        public virtual Player Player { get; set; }
    }
}
