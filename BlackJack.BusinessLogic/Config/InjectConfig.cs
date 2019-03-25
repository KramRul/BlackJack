using BlackJack.DataAccess.UnitOfWorks;
using BlackJack.DataAccess.UnitOfWorks.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Data.SqlClient;

namespace BlackJack.BusinessLogic.Config
{
    public static class InjectConfig
    {
        public static void InjectConfigures(this IServiceCollection services, IConfiguration config)
        {
            services.Scan(scan => scan
                .FromCallingAssembly()
                .FromApplicationDependencies(a => a.FullName.StartsWith("BlackJack"))
                .AddClasses(classes => classes.Where(type => type.Name.Contains("Service") || type.Name.Contains("Helper") || type.Name.Contains("Provider")))
                .AsImplementedInterfaces()
            );
            services.AddTransient<IBaseUnitOfWork, DapperUnitOfWork>();
            services.AddSingleton<ConnectionStringInjector>();

            using (var serviceProvider = services.BuildServiceProvider())
            {
                var connectionStringInjector = serviceProvider.GetService<ConnectionStringInjector>();
                services.AddTransient<IDbConnection>(db => new SqlConnection(connectionStringInjector.ConnectionString));
            }
        }
    }
}
