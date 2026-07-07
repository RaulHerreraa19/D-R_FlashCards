using DR_FlashCards.Models;

namespace DR_FlashCards.DTOs
{
    public class UsersDTO
    {
        public UsersDTO() { }


        public UsersDTO(UsersModel model)
        {
            Id = model.Id;
            Name = model.Name;
            Email = model.Email;
            Password = model.Password;
            CreatedAt = model.CreatedAt;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; } 
        public string Token { get; set; } // Agregado para el JWT

    }

}
