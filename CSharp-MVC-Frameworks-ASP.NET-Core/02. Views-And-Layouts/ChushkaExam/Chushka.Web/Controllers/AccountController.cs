using Chushka.Models;
using Chushka.Web.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Chushka.Web.Controllers
{
    public class AccountController : Controller
    {
        private SignInManager<ChushkaUser> signIn;

        public AccountController(SignInManager<ChushkaUser> signIn)
        {
            this.signIn = signIn;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            var user = this.signIn.UserManager.Users.FirstOrDefault(u => u.UserName == model.Username);
            this.signIn.SignInAsync(user, model.RememberMe).Wait();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            var user = new ChushkaUser()
            {
                Email = model.Email,
                FullName = model.FullName,
                UserName = model.Username
            };
            var result = this.signIn.UserManager.CreateAsync(user, model.Password).Result;

            if(this.signIn.UserManager.Users.Count() == 1)
            {
                var roleResult = this.signIn.UserManager.AddToRoleAsync(user, "Administrator").Result;
                if (roleResult.Errors.Any())
                {
                    return this.View();
                }
            }

            if (result.Succeeded)
            {
                this.signIn.SignInAsync(user, false).Wait();
                return this.RedirectToAction("Index", "Home");
            }

            return this.View();
        }
    }
}
