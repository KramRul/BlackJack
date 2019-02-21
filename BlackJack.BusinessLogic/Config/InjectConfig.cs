using BlackJack.BusinessLogic.Interfaces.Providers;
using BlackJack.BusinessLogic.Interfaces.Services;
using BlackJack.BusinessLogic.Providers;
using BlackJack.BusinessLogic.Services;
using BlackJack.DataAccess;
using BlackJack.DataAccess.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BlackJack.BusinessLogic.Config
{
    public static class InjectConfig
    {
        public static void InjectConfigures(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, EFUnitOfWork>();
            //services.AddTransient<IGameService, GameService>();
            services.AddTransient<IPlayerService, PlayerService>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IJwtProvider, JwtProvider>();
            //services.AddTransient<IDealerService, DealerService>();
            //services.AddTransient<IBotService, BotService>();
        }
    }
}
