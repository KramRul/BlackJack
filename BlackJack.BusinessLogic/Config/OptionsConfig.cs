using BlackJack.BusinessLogic.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlackJack.BusinessLogic.Config
{
    public static class OptionsConfig
    {
        public static void OptionsConfigures(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JWTOptions>(configuration.GetSection("JWTOptions"));
        }
    }
}
