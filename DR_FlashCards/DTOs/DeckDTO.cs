using DR_FlashCards.Models;

namespace DR_FlashCards.DTOs
{
    public class DeckDTO
    {

        public DeckDTO()
        {

        }

        public DeckDTO(DeckModel model) 
        {
            Id = model.Id;
            Name = model.Name;           

        }

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;        
        public int IdExam { get; set; } // Foreign key to ExamModel
        public int IdUser { get; set; } // Foreign key to UsersModel
        public ExamsDTO? Exam { get; set; }
        public UsersDTO? UsersDTO { get; set; }
        public IEnumerable<FlashCardDTO> FlashCards { get; set; } = Enumerable.Empty<FlashCardDTO>();

    }
}
