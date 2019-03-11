using BlackJack.BusinessLogic.Providers;
using BlackJack.BusinessLogic.Providers.Interfaces;
using BlackJack.BusinessLogic.Services;
using BlackJack.BusinessLogic.Services.Interfaces;
using BlackJack.DataAccess;
using BlackJack.DataAccess.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BlackJack.BusinessLogic.Config
{
    public static class InjectConfig
    {
        public static void InjectConfigures(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, DapperUnitOfWork>();
            services.AddTransient<IGameService, GameService>();
            services.AddTransient<IPlayerService, PlayerService>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IJwtProvider, JwtProvider>();
            services.AddTransient<IHistoryService, HistoryService>();
            services.AddTransient<IAdditionalRanksService, AdditionalRanksService>();            
        }
    }
}
