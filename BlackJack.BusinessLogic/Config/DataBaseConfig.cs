﻿using BlackJack.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BlackJack.BusinessLogic.Config
{
    public static class DataBaseConfig
    {
        public static void DataBaseConfigures(this IServiceCollection services)
        {
            using (var serviceProvider = services.BuildServiceProvider())
            {
                var connectionStringInjector = serviceProvider.GetService<ConnectionStringInjector>();
                services.AddDbContext<ApplicationContext>(options =>
                    options.UseSqlServer(connectionStringInjector.ConnectionString, b => b.MigrationsAssembly("BlackJack.WEB")));
            }           
        }
    }
}
