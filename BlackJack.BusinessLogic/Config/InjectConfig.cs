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
                .FromApplicationDependencies(a => a.FullName.StartsWith("BlackJack"))
                .AddClasses(classes => classes.Where(type => type.Name.Contains("Service") || type.Name.Contains("Helper") || type.Name.Contains("Provider")))
                .AsImplementedInterfaces()
            );
            services.AddTransient<IBaseUnitOfWork, DapperUnitOfWork>();
        }
    }
}
/*
 * services.Scan(scan => scan
                .FromExecutingAssembly()
                .FromAssemblies(
                typeof(IAccountService).Assembly,
                typeof(IGameService).Assembly,
                typeof(IHistoryService).Assembly,
                typeof(IPlayerService).Assembly,
                typeof(IRanksHelper).Assembly,
                typeof(IJwtProvider).Assembly
                )
                .FromApplicationDependencies(a => a.FullName.StartsWith("BlackJack"))
                .AddClasses(publicOnly: true)
                .AsImplementedInterfaces()
            );
 */
/*services.Scan(scan => scan
                .FromExecutingAssembly()
                .FromApplicationDependencies(a => a.FullName.StartsWith("BlackJack"))
                .AddClasses(publicOnly: true)
                .AsMatchingInterface((service, filter) =>
                    filter.Where(implementation => implementation.Name.Equals($"I{service.Name}", StringComparison.OrdinalIgnoreCase)))
                .WithTransientLifetime()
            );*/
