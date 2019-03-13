using BlackJack.BusinessLogic.Providers.Interfaces;
using BlackJack.BusinessLogic.Services.Interfaces;
using BlackJack.DataAccess.UnitOfWorks;
using BlackJack.DataAccess.UnitOfWorks.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BlackJack.BusinessLogic.Config
{
    public static class InjectConfig
    {
        public static void InjectConfigures(this IServiceCollection services)
        {
            services.Scan(scan => scan
                .FromCallingAssembly()
                    /*.AddClasses(classes => classes.AssignableTo<IUnitOfWork>())
                        .AsImplementedInterfaces()
                        .WithTransientLifetime()*/
                    .AddClasses(classes => classes.AssignableTo<IGameService>())
                        .AsImplementedInterfaces()
                        .WithTransientLifetime()
                    .AddClasses(classes => classes.AssignableTo<IPlayerService>())
                        .AsImplementedInterfaces()
                        .WithTransientLifetime()
                    .AddClasses(classes => classes.AssignableTo<IAccountService>())
                        .AsImplementedInterfaces()
                        .WithTransientLifetime()
                    .AddClasses(classes => classes.AssignableTo<IJwtProvider>())
                        .AsImplementedInterfaces()
                        .WithTransientLifetime()
                    .AddClasses(classes => classes.AssignableTo<IHistoryService>())
                        .AsImplementedInterfaces()
                        .WithTransientLifetime()
                    .AddClasses(classes => classes.AssignableTo<IRanksHelper>())
                        .AsImplementedInterfaces()
                        .WithTransientLifetime()
            );
            services.AddTransient<IUnitOfWork, DapperUnitOfWork>();
        }
    }
}