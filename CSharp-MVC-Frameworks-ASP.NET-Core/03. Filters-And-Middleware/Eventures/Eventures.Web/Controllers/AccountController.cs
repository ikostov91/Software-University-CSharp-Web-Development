using AutoMapper;
using Eventures.Models;
using Eventures.Web.ViewModels.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Eventures.Web.Controllers
{
    public class AccountController : Controller
    {
        private SignInManager<EventureUser> signInManager;
        private IPasswordHasher<EventureUser> hasher;
        private readonly IMapper mapper;

        public AccountController(SignInManager<EventureUser> signInManager,
            IPasswordHasher<EventureUser> passwordHasher,
            IMapper mapper)
        {
            this.signInManager = signInManager;
            this.hasher = passwordHasher;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (this.signInManager.IsSignedIn(User))
            {
                return this.RedirectToAction("Index", "Home");
            }
            return this.View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            var user = this.signInManager.UserManager.Users.FirstOrDefault(u => u.UserName == model.Username);
            if (user == null)
            {
                return this.RedirectToAction("Login", "Account");
            }
            var result = this.hasher.VerifyHashedPassword(user, user.PasswordHash, model.Password);
            if (result == PasswordVerificationResult.Failed)
            {
                return this.RedirectToAction("Login", "Account");
            }

            this.signInManager.SignInAsync(user, model.RememberMe).Wait();
            return this.RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            if (this.signInManager.IsSignedIn(User))
            {
                return this.RedirectToAction("Index", "Home");
            }
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = this.mapper.Map<EventureUser>(model);
                //var user = new EventureUser()
                //{
                //    UserName = model.Username,
                //    Email = model.Email,
                //    FirstName = model.FirstName,
                //    LastName = model.LastName,
                //    UniqueCitizenNumber = model.UniqueCitizenNumber
                //};
                var result = this.signInManager.UserManager.CreateAsync(user, model.Password).Result;

                if (result.Succeeded)
                {
                    this.signInManager.SignInAsync(user, false).Wait();
                    return this.RedirectToAction("Index", "Home");
                }

                return this.View();
            }
            else
            {
                return this.View(model);
            }
        }

        [HttpGet]
        [Authorize]
        public IActionResult Logout()
        {
            this.signInManager.SignOutAsync();
            return this.RedirectToAction("Index", "Home");
        }
    }
}
