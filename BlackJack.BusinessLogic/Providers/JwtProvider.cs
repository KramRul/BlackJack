using BlackJack.DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using BlackJack.BusinessLogic.Models;
using Microsoft.Extensions.Options;
using BlackJack.BusinessLogic.Providers.Interfaces;

namespace BlackJack.BusinessLogic.Providers
{
    public class JwtProvider: IJwtProvider
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<Player> _userManager;
        private readonly AuthenticationOptions _authenticationOptions;

        public JwtProvider(UserManager<Player> userManager, IOptions<AuthenticationOptions> authenticationOptions)
        {
            _userManager = userManager;
            _authenticationOptions = authenticationOptions.Value;
        }

        public async Task<string> GenerateJwtToken(string email, Player user, double? expiredHours = null)
        {
            var roles = await _userManager.GetRolesAsync(user);

            List<Claim> claims = new List<Claim>
            {
                //new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationOptions.Key));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddHours(expiredHours ?? Convert.ToDouble(_authenticationOptions.Lifetime));

            var token = new JwtSecurityToken(
                _authenticationOptions.Issuer,
                _authenticationOptions.Issuer,
                claims,
                expires: expires,
                signingCredentials: credentials
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            var result = tokenHandler.WriteToken(token);

            return result;
        }

        public async Task<string> ReadToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var convertToken = tokenHandler.ReadToken(token);

            return "";
        }
    }
}
