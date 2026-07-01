using DR_FlashCards.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DR_FlashCards.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
           

            var flashCards = new List<FlashCardModel>
            {
                new FlashCardModel { Id = 1, Question = "What is the capital of France?", Answer = "Paris" },
                new FlashCardModel { Id = 2, Question = "What is 2 + 2?", Answer = "4" },
                new FlashCardModel { Id = 3, Question = "What is the largest planet in our solar system?", Answer = "Jupiter" }
            };
            return View(flashCards);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult FlashCards()
        {
            var flashCards = new List<FlashCardModel>
            {
                new FlashCardModel { Id = 1, Question = "What is the capital of France?", Answer = "Paris" },
                new FlashCardModel { Id = 2, Question = "What is 2 + 2?", Answer = "4" },
                new FlashCardModel { Id = 3, Question = "What is the largest planet in our solar system?", Answer = "Jupiter" }
            };
            return Ok(flashCards);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

       
    }
}
