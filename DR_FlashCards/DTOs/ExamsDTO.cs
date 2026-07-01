using DR_FlashCards.Models;

namespace DR_FlashCards.DTOs
{
    public class ExamsDTO
    {

        public ExamsDTO() 
        {             
        }

        public ExamsDTO(ExamModel exam)
        {
            Id = exam.Id;
            Subject = exam.Subject;            
            ExamDate = exam.ExamDate;
            Decks = exam.Decks.Select(deck => new DeckDTO(deck)).ToList();
        }

        public int Id { get; set; }
        public string Subject { get; set; } = string.Empty;        
        public DateTime ExamDate { get; set; }
        public IEnumerable<DeckDTO> Decks { get; set; } = Enumerable.Empty<DeckDTO>();
    }
}
