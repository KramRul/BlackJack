namespace BlackJack.DataAccess.Entities
{
    public class Bot : BaseEntity
    {
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public decimal Bet { get; set; }
    }
}
