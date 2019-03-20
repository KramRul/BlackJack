using BlackJack.DataAccess.Enums;
using Dapper.Contrib.Extensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlackJack.DataAccess.Entities
{
    public class Game : BaseEntity
    {
        public GameStateType GameState { get; set; }
        public string WonName { get; set; }

        public string PlayerId { get; set; }
        [Computed]
        [ForeignKey("PlayerId")]
        public virtual Player Player { get; set; }
    }
}
