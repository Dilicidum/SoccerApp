using Application.Interfaces.Identity;
using Application.Responses;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Identity.Models;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
namespace Identity.Managers
{
    public class JWTManager : ITokenManager
    {
        private AppSettings appSettings;

        public JWTManager(IOptions<AppSettings> options)
        {
            appSettings = options.Value;
        }
        public async Task<UserResponse> GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            var tokenDescription = new SecurityTokenDescriptor()
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]{
                    new Claim(ClaimTypes.NameIdentifier,user.Id)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHandler.CreateJwtSecurityToken(tokenDescription);
            var tokenString = tokenHandler.WriteToken(token);
            UserResponse userResponse = new UserResponse(user.Id, tokenString, token.ValidTo);
            return userResponse;
        }
    }
}
