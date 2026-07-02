using DR_FlashCards.Data;
using DR_FlashCards.DTOs;
using DR_FlashCards.Interfaces;
using DR_FlashCards.Models;
using Microsoft.EntityFrameworkCore;

namespace DR_FlashCards.Services
{    
    public class DeckService : IDeckService
    {
        private readonly IDeckService _deckInterface;

        private readonly ApplicationDbContext _dBContext;
        public DeckService(ApplicationDbContext dBContext, IDeckService deckInterface) 
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
        public async Task<DeckDTO> GetDeckById(int id)
        {
            var deck = new DeckDTO();
            try
            {
                deck = await _dBContext.Decks
                    .Where(d => d.Id == id)
                    .Include(d => d.IdExam)
                    .Select(d => new DeckDTO
                    {
                        Id = d.Id,
                        Name = d.Name,
                        IdExam = d.IdExam
                    })
                    .FirstOrDefaultAsync();                
            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., log it)
                throw new Exception($"An error occurred while retrieving the deck with ID {id}: {ex.Message}", ex);
            }
        }

        public async Task<DeckDTO> CreateDeck(DeckDTO deck)
        {
             
            try
            {
                var newDeck = new DeckModel
                {
                    Name = deck.Name,
                    IdExam = deck.IdExam,
                    IdUser = deck.IdUser
                };
                _dBContext.Decks.Add(newDeck);
                await _dBContext.SaveChangesAsync();

                var createdDeck = new DeckDTO
                {
                    Id = newDeck.Id,
                    Name = newDeck.Name,
                    IdExam = newDeck.IdExam,
                    IdUser = newDeck.IdUser
                };

                return createdDeck;
            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., log it)
                throw new Exception($"An error occurred while creating the deck: {ex.Message}", ex);

            }
        }

        public async Task<DeckDTO> UpdateDeck(int id, DeckDTO deck)
        {
            try
            {
                var existingDeck = await _dBContext.Decks.FindAsync(id);
                if (existingDeck == null)
                {
                    throw new Exception($"Deck with ID {id} not found.");
                }

                existingDeck.Name = deck.Name;
                existingDeck.IdExam = deck.IdExam;
                await _dBContext.SaveChangesAsync();

                var updatedDeck = new DeckDTO
                {
                    Id = existingDeck.Id,
                    Name = existingDeck.Name,
                    IdExam = existingDeck.IdExam,
                    IdUser = existingDeck.IdUser
                };

                return updatedDeck;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while updating the deck: {ex.Message}", ex);
            }

        }

        public async Task<bool> DeleteDeck(int id)
        {
            try
            {            
            var existingDeck = await _dBContext.Decks.FindAsync(id);
            if(existingDeck == null)
            {
                throw new Exception($"Deck with ID {id} not found.");
            }
            _dBContext.Decks.Remove(existingDeck);
            await _dBContext.SaveChangesAsync();

            return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while deleting the deck: {ex.Message}", ex);
            }   

        }

    }
}
