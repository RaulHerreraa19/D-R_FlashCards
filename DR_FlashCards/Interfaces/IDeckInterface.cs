using DR_FlashCards.Models;

namespace DR_FlashCards.Interfaces
{
    public interface IDeckInterface
    {
        public Task<List<DeckModel>> GetAllDecks();
        public Task<DeckModel> GetDeckById(int id);
        public Task<DeckModel> CreateDeck(DeckModel deck);
        public Task<DeckModel> UpdateDeck(int id, DeckModel deck);
        public Task<bool> DeleteDeck(int id);

    }
}
