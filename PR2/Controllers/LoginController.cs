using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Security.Claims;
using PR2.Data;

namespace PR2.Controllers
{
    public class LoginController : Controller
    {
        private readonly MyApplicationContex _contex;

        public LoginController(ILogger<HomeController> logger, MyApplicationContex contex)
        {
            
            _contex = contex;
        }

        [HttpPost]
        public async Task<IActionResult> IndexAsync(string login, string password)
        {
            var existUser = _contex.Users.FirstOrDefault(u => u.Login == login && u.Password == password);
            if (existUser == null)
            {
                ModelState.AddModelError("invalidLoginOrPassword", "Неверный логин или пароль");

                return View();
            }
            await AuthenticateAsync(existUser);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task <IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync(string login, string password)
        {
            var existUser = _contex.Users.Any(u => u.Login == login);
            if (existUser)
            {
                ModelState.AddModelError("invalidLogin", "Такой пользователь уже существует");
                return View();
            }

            var user = (new User { Login = login, Password = password });
            _contex.Users.Add(user);
            _contex.SaveChanges();

            await AuthenticateAsync(user);

            return RedirectToAction("Index", "Home");
        }

        private async Task AuthenticateAsync(User user)
        {
            var claims = new List<Claim> { 
                new Claim("Id", user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Login)};


            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
        }
    }
}
