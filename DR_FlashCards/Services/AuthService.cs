using DR_FlashCards.Data;
using DR_FlashCards.DTOs;
using DR_FlashCards.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DR_FlashCards.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;
        public AuthService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UsersDTO> Login(string email, string password)
        {
            UsersDTO user = new UsersDTO();
            var encryptedPassword 
            try
            {
                var checkEmail = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
                if (checkEmail != null)
                {
                    var checkPassword = await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);

                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during the login process
                throw new Exception("An error occurred while attempting to log in.", ex);
            }
            return user;
        }

        public async Task<UsersDTO> Register(string name, string email, string password)
        {
            // Implement your registration logic here
            // For example, you can create a new user in the database
            // If the registration is successful, return a UsersDTO object
            // If the registration fails, throw an exception or return null
            // Example implementation:
        }

    }
}
