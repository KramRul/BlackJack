using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;

namespace BlackJack.BusinessLogic.Config
{
    public static class JwtConfig
    {
        public static void JwtConfigures(this IServiceCollection services, IConfiguration configuration)
        {
            //var serviceProvider = services.BuildServiceProvider();
            //var authenticationOptions = serviceProvider.GetRequiredService<IOptions<AuthenticationOptions>>().Value;
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
                    ValidIssuer = configuration["JWTOptions:Issuer"],
                    ValidAudience = configuration["JWTOptions:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWTOptions:Key"])),
                    ClockSkew = TimeSpan.Zero
                };
            });
        }
    }
}
