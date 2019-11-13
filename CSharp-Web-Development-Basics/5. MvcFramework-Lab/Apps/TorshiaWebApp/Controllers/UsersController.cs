using System;
using System.Linq;
using SIS.HTTP.Cookies;
using SIS.HTTP.Responses;
using SIS.MvcFramework;
using SIS.MvcFramework.Services;
using TorshiaWebApp.Models;
using TorshiaWebApp.ViewModels;

namespace TorshiaWebApp.Controllers
{
    public class UsersController : BaseController
    {
        private IHashService hashService;

        public UsersController(IHashService hashService)
        {
            this.hashService = hashService;
        }

        [HttpGet]
        public IHttpResponse Register()
        {
            return this.View();
        }

        [HttpPost]
        public IHttpResponse Register(RegisterInputModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Username))
            {
                return this.BadRequestError("Username is invalid.");
            }

            if (string.IsNullOrWhiteSpace(model.Email))
            {
                return this.BadRequestError("Email is invalid.");
            }

            if (model.Password != model.ConfirmPassword)
            {
                return this.BadRequestError("Passwords do not match.");
            }

            string hashedPassword = this.hashService.Hash(model.Password);
            var role = UserRole.User;
            if (!this.Db.Users.Any())
            {
                role = UserRole.Admin;
            }

            var user = new User()
            {
                Username = model.Username,
                Password = hashedPassword,
                Email = model.Email,
                Role = role
            };

            try
            {
                this.Db.Users.Add(user);
                this.Db.SaveChanges();
            }
            catch (Exception)
            {
                return this.ServerError("Something wrong happened.");
            }

            return this.Redirect("/users/login");
        }

        [HttpGet]
        public IHttpResponse Login()
        {
            return this.View();
        }

        [HttpPost]
        public IHttpResponse Login(LoginInputModel model)
        {
            string hashedPassword = this.hashService.Hash(model.Password);

            var user = this.Db.Users.FirstOrDefault(x => x.Username == model.Username && x.Password == hashedPassword);
            if (user == null)
            {
                return this.BadRequestError("Username or password is invalid.");
            }

            var mvcUser = new MvcUserInfo()
            {
                Username = user.Username,
                Role = user.Role.ToString(),
                Info = user.Email
            };

            var userCookie = this.UserCookieService.GetUserCookie(mvcUser);
            var cookie = new HttpCookie(".auth-Torshia", userCookie, 7) { HttpOnly = true };
            this.Response.Cookies.Add(cookie);

            return this.Redirect("/");
        }
    }
}
