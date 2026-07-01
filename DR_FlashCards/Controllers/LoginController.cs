using Microsoft.AspNetCore.Mvc;
using DR_FlashCards.Services;

namespace DR_FlashCards.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService;
        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            var text = " sadadsadadsa";
            text = text + "aaaaaa";
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = _userService.Login(email, password).Result;

            if (user == null)
            {
                Console.WriteLine("Login failed: Invalid email or password.");  

            }

            return Ok(user);

        }
    }
}
