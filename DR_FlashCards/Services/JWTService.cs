using DR_FlashCards.DTOs;

namespace DR_FlashCards.Services
{
    public class JWTService
    {
        public static string GenerateToken(UsersDTO user, string secretKey)
        {
            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var key = System.Text.Encoding.ASCII.GetBytes(secretKey);
            var tokenDescriptor = new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(
                    new[] { new System.Security.Claims.Claim("id", user.Id.ToString()),
                    new System.Security.Claims.Claim("name", user.Name),
                    new System.Security.Claims.Claim("email", user.Email) }
                ),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(key), Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
