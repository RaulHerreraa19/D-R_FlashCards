using DR_FlashCards.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DR_FlashCards.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {                     
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }        
       
    }
}
