using DR_FlashCards.Data;
using DR_FlashCards.DTOs;
using DR_FlashCards.Interfaces;
using DR_FlashCards.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Runtime.Intrinsics.Arm;

namespace DR_FlashCards.Services
{    
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<UsersDTO>> GetUsers()
        {
            var  users = new List<UsersDTO>();
            try
            {
                users = await _context.Users
                    .Select(u => new UsersDTO
                    {
                        Id = u.Id,
                        Name = u.Name,
                        Email = u.Email,
                        Password = u.Password,
                        CreatedAt = u.CreatedAt
                    })
                    .ToListAsync();

            }
            catch (Exception ex)
            {                
                throw new Exception("An error occurred while retrieving users.", ex);
            }
                      

            
            return users; 
         }

        public async Task<UsersDTO> Login(string email, string password)
        {

            throw new NotImplementedException();
        }

        public async Task<UsersDTO> Register(string name, string email, string password)
        {
            // Simulate an asynchronous operation
            await Task.Delay(1000);
            // Return a sample user for demonstration purposes
            return new UsersDTO
            {
                Id = 1,
                Name = name,
                Email = email,
                Password = password,
                CreatedAt = DateTime.UtcNow
            };
        }
    }
}
