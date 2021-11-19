using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PracaInzynierskaAPI.API.JWT.Interfaces;
using PracaInzynierskaAPI.API.JWT.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierskaAPI.API.JWT
{
    public class JwtService: IJwtService
    {
        private readonly IOptions<JwtOptions> options;
        private readonly SigningCredentials signingCredentials;


        public JwtService(IOptions<JwtOptions> options)
        {
            this.options = options;
            var issuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("eaBMU2nbbZmt43sUwByUpJJF6Y5mG2g5N49sQFUpJFcGFJdyhxskR3bxd527kax3UcXHnB"));
            this.signingCredentials = new SigningCredentials(issuerSigningKey, SecurityAlgorithms.HmacSha256);
        }

        public Task<JwtAuthenticationTokenModel> CreateToken(Guid userId)
        {
            if (Guid.Empty == userId)
                return Task.FromResult<JwtAuthenticationTokenModel>(null);

            var now = DateTime.UtcNow;
            var nowEpoch = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
            var jwtClaims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.NameId, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.FamilyName, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, nowEpoch.ToString()),
            };

            var expires = now.AddHours(this.options.Value.ExpiryHours);
            var jwt = new JwtSecurityToken(
                 issuer: this.options.Value.Issuer,
                claims: jwtClaims,
                notBefore: now,
                expires: expires,
                signingCredentials: this.signingCredentials
            );

            return Task.FromResult(
                new JwtAuthenticationTokenModel(
                    "Bearer",
                    new JwtSecurityTokenHandler().WriteToken(jwt)
                    )
                );
        }
    }
}
