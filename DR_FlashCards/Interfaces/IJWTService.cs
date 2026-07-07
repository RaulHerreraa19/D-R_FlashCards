using DR_FlashCards.DTOs;

namespace DR_FlashCards.Interfaces
{
    public interface IJWTService
    {
        public string GenerateToken(UsersDTO user, string secretKey);
        public int? ValidateToken(string token, string secretKey);
        
    }
}
