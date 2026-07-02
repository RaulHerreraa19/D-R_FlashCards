using DR_FlashCards.DTOs;
using DR_FlashCards.Models;

namespace DR_FlashCards.Interfaces
{
    public interface IDeckService
    {
        public Task<List<DeckDTO>> GetAllDecks(int userId, int examId);
        public Task<DeckDTO> GetDeckById(int id);
        public Task<DeckDTO> CreateDeck(DeckDTO deck);
        public Task<DeckDTO> UpdateDeck(int id, DeckDTO deck);
        public Task<bool> DeleteDeck(int id);

    }
}
