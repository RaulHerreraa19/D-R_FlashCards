using DR_FlashCards.DTOs;

namespace DR_FlashCards.Interfaces
{

    public interface IAuthService
    {
        public Task<UsersDTO> Login(string email, string password);
        public Task<UsersDTO> Register(string name, string email, string password);
    }
}
