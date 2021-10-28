using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ACA.DTO;
using ACA.DTO.User;
using Microsoft.IdentityModel.Tokens;

namespace ACA.Token
{
    public class TokenManager
    {
        public static string SecretKey = "azheazjh kazhe khH zeajJBHerzjahbr JBRjza";
        public static string Issuer = "Monsite.com";
        public static string Audience = "Maconso.com";

        public UserDTO Authenticate(UserDTO user)
        {
            if (user.Email is null)
            {
                throw new ArgumentNullException();
            }
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
            SigningCredentials credentials = new(securityKey, SecurityAlgorithms.HmacSha512);
            Claim[] Myclaims = new[]
            {
                new Claim(ClaimTypes.Name,user.Email),
                new Claim(ClaimTypes.Role,user.IsAdmin ? "admin" : "user" )
            };
            JwtSecurityToken token = new(
                claims: Myclaims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials,
                issuer: Issuer,
                audience: Audience

                );
            JwtSecurityTokenHandler tokenHandler = new();
            user.Token = tokenHandler.WriteToken(token);
            return user;
        }
    }
}
