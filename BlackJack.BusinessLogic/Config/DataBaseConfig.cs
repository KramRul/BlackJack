using BlackJack.DataAccess;
using BlackJack.DataAccess.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlackJack.BusinessLogic.Config
{
    public static class DataBaseConfig
    {
        public static void DataBaseConfigures(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(options =>
            options.UseSqlServer(configuration.ConnectionString(), b => b.MigrationsAssembly("BlackJack.WEB")));
        }
    }
}
