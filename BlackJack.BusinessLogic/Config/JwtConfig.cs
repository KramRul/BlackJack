using BlackJack.BusinessLogic.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace BlackJack.BusinessLogic.Config
{
    public static class JwtConfig
    {
        public static void JwtConfigures(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var opt = serviceProvider.GetRequiredService<IOptions<AuthenticationOptions>>().Value;

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = opt.Issuer,
                    ValidAudience = opt.Issuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(opt.Key)),
                    ClockSkew = TimeSpan.Zero
                };
            });
        }
    }
}
