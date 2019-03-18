using Microsoft.Extensions.Configuration;

namespace BlackJack.DataAccess.Config
{
    public static class ConnectionStringConfig
    {
        public static string ConnectionString(this IConfiguration configuration)
        {
            return configuration.GetConnectionString("DefaultConnection");
        }
    }
}
