using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using MySchoolWebSite.Models.Abstract;
using MySchoolWebSite.Domains.Entities;
using MySchoolWebSite.ViewModels;

namespace MySchoolWebSite.Controllers
{
    public class AccountController : Controller
    {
        private IUserRepository userRepository;
        private IRoleRepository roleRepository;
        public AccountController(IUserRepository u, IRoleRepository r)
        {
            userRepository = u;
            roleRepository = r;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = userRepository.Get(model.Email, model.Password);
                if (user != null)
                {
                    user.Role = roleRepository.Get(user.RoleId);
                    await Authenticate(user); // аутентификация

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }
        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult Registration()
        {
            ViewBag.Roles = roleRepository.GetAll();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Registration(RegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                User user = userRepository.Get(model.Email, model.Password);
                if (user == null)
                {
                    user = new User()
                    {
                        Email = model.Email, Password = model.Password, RoleId = model.RoleId,
                        Role = roleRepository.Get(model.RoleId)
                    };
                    // добавляем пользователя в бд
                    await userRepository.Add(user);
                    user = userRepository.Get(model.Email, model.Password);
                    await Authenticate(user); // аутентификация

                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }

        private async Task Authenticate(User user)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.Name)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
