using DR_FlashCards.Data;
using DR_FlashCards.DTOs;
using DR_FlashCards.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DR_FlashCards.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly IJWTService _jwtService;
        public AuthService(ApplicationDbContext context, IJWTService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        public async Task<UsersDTO> Login(string email, string password)
        {
            // Replace with your actual secret key from appsettings
            var secretkey = "asda";

            UsersDTO user = new UsersDTO();            
            try 
            {
                var checkEmail = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
                if (checkEmail != null)
                {
                    // Nota: Aquí se debería comparar contraseñas hasheadas en un proyecto real.
                    var checkPassword = await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
                    if (checkPassword != null) {
                        user = new UsersDTO
                        {
                            Id = checkPassword.Id,
                            Name = checkPassword.Name,
                            Email = checkPassword.Email
                        };
                        
                        // Generamos el token
                        var token = _jwtService.GenerateToken(user, secretkey);
                        user.Token = token;
                    }
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
            //return no method
            return null;


        }

    }
}
