using DR_FlashCards.Models;
using System.Data.Common;
using System.Runtime.Intrinsics.Arm;

namespace DR_FlashCards.Services
{
    public interface IUserService
    {
        public Task<UsersModel> GetUsers();
        public Task<UsersModel> Login(string email, string password);
    }
    public class UserService : IUserService
    {
        public UserService()
        {
          
        }

        public async Task<UsersModel> GetUsers()
        {
            // Simulate an asynchronous operation
            await Task.Delay(1000);
            // Return a sample user for demonstration purposes
            return new UsersModel
            {
                Id = 1,
                Name = "John Doe",
                Email = "john.doe@example.com",
                Password = "password123",
                CreatedAt = DateTime.UtcNow
            };
         }

        public async Task<UsersModel> Login(string email, string password)
        {

            // Simulate an asynchronous operation
            await Task.Delay(1000);
            // Return a sample user for demonstration purposes
            return new UsersModel
            {
                Id = 1,
                Name = "John Doe",
                Email = email,
                Password = password,
                CreatedAt = DateTime.UtcNow
            };
        }
    }
}
