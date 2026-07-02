using DR_FlashCards.DTOs;

namespace DR_FlashCards.Interfaces
{
    public interface IFlashCardsService
    {
        public Task<List<FlashCardDTO>> GetAllFlashCards(int userId, int deckId);
        public Task<FlashCardDTO> GetFlashCardById(int id);
        public Task<FlashCardDTO> CreateFlashCard(FlashCardDTO flashCard);
        public Task<FlashCardDTO> UpdateFlashCard(int id, FlashCardDTO flashCard);
        public Task DeleteFlashCard(int id);
    }
}
