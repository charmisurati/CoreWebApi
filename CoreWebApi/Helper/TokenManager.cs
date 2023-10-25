using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CoreWebApi.Helper
{
    public class TokenManager
    {

        public static string GenerateToken(string userName, string password)
        {
            List<Claim> claims = GetClaims(userName);
            byte[] key = Encoding.ASCII.GetBytes("p]IL\\Fp7-iQ|4S5BKfsdf323c232yfg0M9M");
            JwtSecurityToken tokenOptions = new(
                issuer: "https://localhost.com",
                audience: "Shoppy",
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            );
            string token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return token;
        }
        private static List<Claim> GetClaims(string userName)
        {
            List<Claim> claims = new()
            {
                //new Claim(ClaimTypes.Name,"Vishal P" ),
                new Claim(ClaimTypes.Email, userName),
            };

            return claims;
        }
    }

}
