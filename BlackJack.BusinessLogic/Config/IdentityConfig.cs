using BlackJack.DataAccess;
using BlackJack.DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace BlackJack.BusinessLogic.Config
{
    public static class IdentityConfig
    {
        public static void IdentityConfigures(this IServiceCollection services)
        {
            services.AddIdentity<Player, IdentityRole>().AddEntityFrameworkStores<ApplicationContext>()
                .AddDefaultTokenProviders();
        }
    }
}
