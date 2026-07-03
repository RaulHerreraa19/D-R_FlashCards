using DR_FlashCards.Data;
using DR_FlashCards.DTOs;
using DR_FlashCards.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace DR_FlashCards.Services
{
    public interface IExamService // metodos
    {
        public Task<List<ExamsDTO>> GetAllExams(int userId);
        public Task<ExamsDTO> GetExamById(int id);
        public Task<ExamsDTO> CreateExam(ExamsDTO exam);
    }
    public class ExamService: IExamService
    {
        private readonly ApplicationDbContext _context;
        public ExamService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<ExamsDTO>> GetAllExams(int userId)
        {            
            var exams = new List<ExamsDTO>();
            try
            {
                exams = await _context.Exams
                .Where(e => e.UserId == userId)
                .Select(e => new ExamsDTO
                {
                    Id = e.Id,
                    Subject = e.Subject,
                    ExamDate = e.ExamDate,
                    Decks = e.Decks.Select(d => new DeckDTO
                    {
                        Id = d.Id,
                        Name = d.Name,
                        FlashCards = d.FlashCards.Select(c => new FlashCardDTO
                        {
                            Id = c.Id,
                            Question = c.Question,
                            Answer = c.Answer
                        }).ToList()
                    }).ToList()
                })
                .ToListAsync();

            }
            catch (Exception ex)
            {
                // Manejar la excepción según sea necesario
                Console.WriteLine($"Error al obtener los exámenes: {ex.Message}");
            }
            return (exams);
        }

        public async Task<ExamsDTO> GetExamById(int id)
        {
            var exam = new ExamsDTO();
            try
            {

            
             exam = await _context.Exams
                .Where(e => e.Id == id)
                .Select(e => new ExamsDTO
                {
                    Id = e.Id,
                    Subject = e.Subject,
                    ExamDate = e.ExamDate,
                    Decks = e.Decks.Select(d => new DeckDTO
                    {
                        Id = d.Id,
                        Name = d.Name,
                        FlashCards = d.FlashCards.Select(c => new FlashCardDTO
                        {
                            Id = c.Id,
                            Question = c.Question,
                            Answer = c.Answer
                        }).ToList()
                    }).ToList()
                })
                .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                // Manejar la excepción según sea necesario
                Console.WriteLine($"Error al obtener el examen: {ex.Message}");
            }

            return exam;
        }
        public async Task<ExamsDTO> CreateExam(ExamsDTO exam)
        {
            var examModel = new ExamModel
            {
                Subject = exam.Subject,
                ExamDate = exam.ExamDate,
                UserId = exam.Decks.FirstOrDefault()?.IdUser ?? 0 // Asignar el UserId del primer deck si existe    
            };
            _context.Exams.Add(examModel);
            await _context.SaveChangesAsync();
            // Asignar el Id generado al DTO
            exam.Id = examModel.Id;
            return exam;
        }


    }

}
