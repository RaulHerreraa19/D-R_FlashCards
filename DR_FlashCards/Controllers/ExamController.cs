using Microsoft.AspNetCore.Mvc;
using DR_FlashCards.Models;
using DR_FlashCards.Services;


namespace DR_FlashCards.Controllers
{

    public class ExamController : Controller
    {

        private readonly IExamService _ExamService;
        public ExamController(IExamService ExamService)
        {
            _ExamService = ExamService;
        }

        public IActionResult Index()  // este es el metodo que se va a llamar cuando se haga un get a /Exam/Index
        {
            var result = _ExamService.GetAllExams().Result; // getexam apenas se va a crear
            return View(result); // vista porque es index si no truena
        }
    }
}
