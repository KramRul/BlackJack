﻿using BlackJack.DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using BlackJack.BusinessLogic.Providers.Interfaces;
using BlackJack.BusinessLogic.Options;

namespace BlackJack.BusinessLogic.Providers
{
    public class JwtProvider: IJwtProvider
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<Player> _userManager;

        public JwtProvider(UserManager<Player> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<string> GenerateJwtToken(string email, Player user, double? expiredHours = null)
        {
            var roles = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var options = _configuration.GetSection("JWTOptions").Get<JWTOptions>();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.Key));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddHours(expiredHours ?? Convert.ToDouble(options.Lifetime));

            var token = new JwtSecurityToken(
                options.Issuer,
                options.Issuer,
                claims,
                expires: expires,
                signingCredentials: credentials
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            var result = tokenHandler.WriteToken(token);

            return result;
        }
    }
}
