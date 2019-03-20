using Microsoft.Extensions.Configuration;

namespace BlackJack.BusinessLogic.Config
{
    public class ConnectionStringInjector
    {
        private readonly IConfiguration _config;

        public ConnectionStringInjector(IConfiguration config)
        {
            _config = config;
        }

        public string ConnectionString
        {
            get
            {
                return _config.GetConnectionString("DefaultConnection");
            }
        }
    }
}
