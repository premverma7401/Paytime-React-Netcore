using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Paytime.Application.Interfaces;
using Paytime.Domain;
using System;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Security
{
    public class JwtGenerator : IJwtGenerator
    {
        // Dont forgot to add Token key in user-secrets
        // Initaialise store by dotnet user-secrets init -p .\Paytime.Api\
        // Set token as dotnet user-secrets set "TokenKey" "super secret key" -p .\Paytime.Api\

        private readonly SymmetricSecurityKey _key;
        public JwtGenerator(IConfiguration configuration)
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenKey"]));

        }
        public string CreateToken(UserModel user)
        {
            var claims = new List<Claim>
            {
               new Claim(JwtRegisteredClaimNames.NameId, user.UserName)
            };


            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }

    }
}
