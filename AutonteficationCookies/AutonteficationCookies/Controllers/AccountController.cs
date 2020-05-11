using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutonteficationCookies.Models;
using AutonteficationCookies.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutonteficationCookies.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserContext dbcontext;
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (!ModelState.IsValid)
                return StatusCode(400, new { ErrorMessage = "Ошибка ввода имени пользователя и пароля" });

            User user = dbcontext.Users.FirstOrDefault();

            if (user != null)
            {
                await Authentificate(loginModel.Email);

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Некорректные логин / пароль");

            return View(loginModel);

        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid && 
                   await dbcontext.Users.FirstOrDefaultAsync(x => x.Email == model.Email) == null)
            {
                await dbcontext.Users.AddAsync(new User {Email = model.Email, Password = model.Password});
                await dbcontext.SaveChangesAsync();

                await Authentificate(model.Email);

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Некорректные логин / пароль");
            
            return View(model);
        }

        private async Task Authentificate(string email)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, email),
                new Claim("custom", "test")
            };

            ClaimsIdentity id = new ClaimsIdentity(claims
                , "Test"//"ApplicationCookie"
                , ClaimsIdentity.DefaultNameClaimType
                , ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }

        public AccountController(UserContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

    }
}