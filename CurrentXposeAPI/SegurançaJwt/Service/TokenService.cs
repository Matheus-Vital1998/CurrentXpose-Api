using CurrentXposeAPI.Entidades;
using CurrentXposeAPI.Segurança.Entidade;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CurrentXposeAPI.Segurança.Service
{
    public class TokenService
    {
        public object GenerateToken(Morador morador)
        {
            var tokenconfig = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("Id", morador.id.ToString()),
                }),
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key.Secret)),
                SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenconfig);
            var tokenString = tokenHandler.WriteToken(token);

            return new
            {
                Token = tokenString
            };
        }
    }
}