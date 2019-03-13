using BlackJack.BusinessLogic.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlackJack.BusinessLogic.Config
{
    public static class OptionsConfig
    {
        public static void OptionsConfigures(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AuthenticationOptions>(configuration.GetSection("JWTOptions"));
        }
    }
}
