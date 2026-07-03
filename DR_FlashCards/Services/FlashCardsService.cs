using DR_FlashCards.Data;
using DR_FlashCards.DTOs;
using DR_FlashCards.Interfaces;

namespace DR_FlashCards.Services
{
    public class FlashCardsService : IFlashCardsService
    {
        private readonly ApplicationDbContext _context;
        public FlashCardsService(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<List<FlashCardDTO>> GetAllFlashCards(int userId, int deckId)
        {
            throw new NotImplementedException();
        }
        public async Task<FlashCardDTO> GetFlashCardById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<FlashCardDTO> CreateFlashCard(FlashCardDTO flashCard)
        {
            throw new NotImplementedException();
        }

        public async Task<FlashCardDTO> UpdateFlashCard(int id, FlashCardDTO flashCard)
        {
            throw new NotImplementedException();
        }

        public async Task<FlashCardDTO> DeleteFlashCard(int id)
        {
            throw new NotImplementedException();
        }
    }
}
