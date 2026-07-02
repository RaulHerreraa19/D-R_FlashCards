using DR_FlashCards.DTOs;
using DR_FlashCards.Models;

namespace DR_FlashCards.Interfaces
{
    public interface IUserService
    {
        public Task<List<UsersDTO>> GetUsers();
        public Task<UsersDTO> Login(string email, string password);
        public Task<UsersDTO> Register(string name, string email, string password);
    }
}
