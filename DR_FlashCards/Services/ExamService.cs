using DR_FlashCards.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
namespace DR_FlashCards.Services
{
    public interface IExamService // metodos
    {
        public Task<List<ExamModel>> GetAllExams();
    }
    public class ExamService: IExamService
    {
        public ExamService() {
            // base de datos o algo asi

        }
        public async Task<List<ExamModel>> GetAllExams()
        {
            // Aqui va la logica para obtener los datos de los examenes de la base de datos

            var exams = new List<ExamModel>
            {
                new ExamModel { Id = 1, Subject = "Math Exam", ExamDate = DateTime.Now},
                new ExamModel { Id = 2, Subject = "Science Exam", ExamDate = DateTime.Now},
                new ExamModel { Id = 3, Subject = "History Exam", ExamDate = DateTime.Now}
            };


            return (exams);
        }
    }

}
