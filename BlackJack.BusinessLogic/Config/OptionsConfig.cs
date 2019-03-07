using BlackJack.BusinessLogic.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.BusinessLogic.Config
{
    public static class OptionsConfig
    {
        public static void OptionsConfigures(this IServiceCollection services, IConfigurationSection _options)
        {
            services.Configure<AuthenticationOptions>(options => _options.Bind(options));
        }
    }
}
