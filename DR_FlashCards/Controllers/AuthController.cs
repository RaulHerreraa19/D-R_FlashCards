using DR_FlashCards.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DR_FlashCards.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _userService;        
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = _userService.Login(email, password);
            if (user != null)
            {
                return Ok(user);
            }
            return Unauthorized();
        }
    }
}
