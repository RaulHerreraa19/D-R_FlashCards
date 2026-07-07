using DR_FlashCards.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Diagnostics;
using DR_FlashCards.DTOs;

namespace DR_FlashCards.Controllers
{
    [Authorize] // Exigirá que el usuario esté logueado
    public class HomeController : Controller
    {
        public IActionResult Index()
        {   
            // Podemos recuperar datos por claims si fuera necesario:
             var userName = User.Identity?.Name;
             var userEmail = User.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value;                  
            var model = new UsersDTO
            {
                Name = userName,
                Email = userEmail
            };
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }      
        
        
       
    }
}
