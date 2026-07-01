using DR_FlashCards.Data;
using DR_FlashCards.DTOs;
using DR_FlashCards.Interfaces;
using DR_FlashCards.Models;
using Microsoft.EntityFrameworkCore;

namespace DR_FlashCards.Services
{    
    public class DeckService : IDeckInterface
    {
        private readonly IDeckInterface _deckInterface;

        private readonly ApplicationDbContext _dBContext;
        public DeckService(ApplicationDbContext dBContext, IDeckInterface deckInterface) 
        {
            _dBContext = dBContext;
            _deckInterface = deckInterface;
        }

        public async Task<List<DeckDTO>> GetAllDecks(int userId, int examId)
        {
            var decks = await _dBContext.Decks
                .Where(d => d.IdUser == userId && d.IdExam == examId)
                .Include(d => d.IdExam)
                .Select(d => new DeckDTO
                {
                    Id = d.Id,
                    Name = d.Name,
                    IdExam = d.IdExam
                })
                .ToListAsync();

            return decks;
        }
        public async Task<DeckModel> GetDeckById(int id)
        {
            return await _deckInterface.GetDeckById(id);
        }

        public async Task<DeckModel> CreateDeck(DeckModel deck)
        {
            return await _deckInterface.CreateDeck(deck);
        }

        public async Task<DeckModel> UpdateDeck(int id, DeckModel deck)
        {
            return await _deckInterface.UpdateDeck(id, deck);
        }

        public async Task<bool> DeleteDeck(int id)
        {
            return await _deckInterface.DeleteDeck(id);
        }

    }
}
