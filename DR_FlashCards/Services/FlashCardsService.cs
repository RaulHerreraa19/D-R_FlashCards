using DR_FlashCards.Data;
using DR_FlashCards.DTOs;
using DR_FlashCards.Interfaces;
using DR_FlashCards.Models;
using Microsoft.EntityFrameworkCore;

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
            List<FlashCardDTO> flashcards = new List<FlashCardDTO>();
            try
            {
                flashcards = await _context.Flashcards
                    .Where(fc => fc.MazoId == deckId)
                    .Select(fc => new FlashCardDTO
                    {
                        Id = fc.Id,
                        Question = fc.Question,
                        Answer = fc.Answer,
                        DeckId = fc.MazoId,
                    })
                    .ToListAsync();

                return flashcards;
            }
            catch( Exception ex )
            {
                Console.WriteLine($"Error occurred while fetching flashcards: {ex.Message}");
            }

            return flashcards;
        }
        public async Task<FlashCardDTO> GetFlashCardById(int id)
        {
            try
            {
                var flashCard = await _context.Flashcards
                    .Where(fc => fc.Id == id)
                    .Select(fc => new FlashCardDTO
                    {
                        Id = fc.Id,
                        Question = fc.Question,
                        Answer = fc.Answer,
                        DeckId = fc.MazoId,
                    })
                    .FirstOrDefaultAsync();
                return flashCard;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while fetching flashcard by ID: {ex.Message}");
                return null;
            }

        }

        public async Task<FlashCardDTO> CreateFlashCard(FlashCardDTO flashCard)
        {
            try
            {
                var newFlashCard = new FlashCardModel
                {
                    Question = flashCard.Question,
                    Answer = flashCard.Answer,
                    MazoId = flashCard.DeckId,
                };
                _context.Flashcards.Add(newFlashCard);
                await _context.SaveChangesAsync();
                flashCard.Id = newFlashCard.Id; // Update the DTO with the generated ID
                return flashCard;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while creating flashcard: {ex.Message}");
                return null;
            }
        }

        public async Task<FlashCardDTO> UpdateFlashCard(int id, FlashCardDTO flashCard)
        {
            try
            {
                var flashCardToUpdate = await _context.Flashcards.FindAsync(id);
                if (flashCardToUpdate == null)
                {
                    return null;
                }

                flashCardToUpdate.Question = flashCard.Question;
                flashCardToUpdate.Answer = flashCard.Answer;
                flashCardToUpdate.MazoId = flashCard.DeckId;

                await _context.SaveChangesAsync();
                return flashCard;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while updating flashcard: {ex.Message}");
                return null;
            }
        }

        public async Task<FlashCardDTO> DeleteFlashCard(int id)
        {
            try
            {
                var flashCardToDelete = await _context.Flashcards.FindAsync(id);
                if (flashCardToDelete == null)
                {
                    return null;
                }

                _context.Flashcards.Remove(flashCardToDelete);
                await _context.SaveChangesAsync();
                return new FlashCardDTO
                {
                    Id = flashCardToDelete.Id,
                    Question = flashCardToDelete.Question,
                    Answer = flashCardToDelete.Answer,
                    DeckId = flashCardToDelete.MazoId
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while deleting flashcard: {ex.Message}");
                return null;
            }
        }
    }
}
