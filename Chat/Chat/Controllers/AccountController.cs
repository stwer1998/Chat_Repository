using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ChatModels;
using ChatWebApplication.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace ChatWebApplication.Controllers
{
    public class AccountController : Controller
    {
        private IAccountReposirory unitofwork;
        public AccountController(IAccountReposirory _unitofwork)
        {
            unitofwork = _unitofwork;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!unitofwork.GetUser(model.Name, model.Password))
            {
                ModelState.AddModelError("", "Пользователь с таким логином и паролем не найден");
            }
            if (ModelState.IsValid && unitofwork.GetUser(model.Name, model.Password))
            {
                await Authenticate(model.Name); // аутентификация

                return RedirectToAction("MyGroups", "Home");
            }
            else return View(model);

        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (unitofwork.GetLogin(model.Name))
            {
                ModelState.AddModelError("Name", "Пользователь с таким именим уже есть");
            }
            if (ModelState.IsValid)
            {
                User u = new User { Name = model.Name, PasswordHash = model.Password };
                unitofwork.AddUser(u);
                await Authenticate(model.Name);
                return RedirectToAction("MyGroups", "Home");
            }
            return View();
        }

        private async Task Authenticate(string userName)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}