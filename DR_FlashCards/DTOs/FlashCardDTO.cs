using DR_FlashCards.Models;

namespace DR_FlashCards.DTOs
{
    public class FlashCardDTO
    {
        public int Id { get; set; }
        public string Question { get; set; } = string.Empty;
        public string Answer { get; set; } = string.Empty;
        public int DeckId { get; set; }
        public int UserId { get; set; }
        public IEnumerable<DeckDTO> Decks { get; set; } = Enumerable.Empty<DeckDTO>();

        public FlashCardDTO() { }
        public FlashCardDTO(FlashCardModel model) 
        {
            Id = model.Id;
            Question = model.Question;
            Answer = model.Answer;
            DeckId = model.MazoId;
            Decks = model.Decks.Select(deck => new DeckDTO(deck)).ToList();
        }

    }
}
