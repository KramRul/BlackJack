using BlackJack.DataAccess.UnitOfWorks;
using BlackJack.DataAccess.UnitOfWorks.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BlackJack.BusinessLogic.Config
{
    public static class InjectConfig
    {
        public static void InjectConfigures(this IServiceCollection services)
        {
            services.Scan(scan => scan
                .FromExecutingAssembly()
                .FromApplicationDependencies(a => a.FullName.StartsWith("BlackJack"))
                .AddClasses(publicOnly: true)
                .AsMatchingInterface((service, filter) =>
                    filter.Where(implementation => implementation.Name.Equals($"I{service.Name}", StringComparison.OrdinalIgnoreCase)))
                .WithTransientLifetime()
            );
            services.AddTransient<IUnitOfWork, DapperUnitOfWork>();
        }
    }
}
