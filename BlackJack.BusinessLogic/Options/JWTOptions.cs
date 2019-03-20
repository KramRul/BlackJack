namespace BlackJack.BusinessLogic.Options
{
    public class JWTOptions
    {
        public string Issuer { get; set; }
        public string Key { get; set; }
        public string Lifetime { get; set; }
    }
}