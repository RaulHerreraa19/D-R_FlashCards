using DR_FlashCards.Models;
using DR_FlashCards.Services;
using Microsoft.AspNetCore.Mvc;

namespace DR_FlashCards.Controllers
{
    

    public class DeckController : Controller
    {
        private readonly DeckService _deckService;
        public DeckController(DeckService deckService)
        {
            _deckService = deckService;

        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DeckModel deck)
        {
            

            return Ok(deck);
        }

    }
}
