using Microsoft.AspNetCore.Mvc;

namespace DR_FlashCards.Controllers
{
    public class DeckController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
