using System;
using System.Linq;
using System.Linq.Expressions;
using ChushkaWebApp.Models;
using ChushkaWebApp.ViewModels.Users;
using SIS.HTTP.Cookies;
using SIS.HTTP.Responses;
using SIS.MvcFramework;
using SIS.MvcFramework.Services;

namespace ChushkaWebApp.Controllers
{
    public class UsersController : BaseController
    {
        private IHashService hashService;

        public UsersController(IHashService hashService)
        {
            this.hashService = hashService;
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
                return this.BadRequestError("Username or password is invalid");
            }

            var mvcUser = new MvcUserInfo()
            {
                Username = user.Username,
                Role = user.Role.ToString(),
                Info = user.Email
            };

            var cookieContent = this.UserCookieService.GetUserCookie(mvcUser);
            var cookie = new HttpCookie(".auth-Chushka", cookieContent, 7) { HttpOnly = true };
            this.Response.Cookies.Add(cookie);

            return this.Redirect("/");
        }

        [HttpGet]
        public IHttpResponse Logout()
        {
            if (!this.Request.Cookies.ContainsCookie(".auth-Chushka"))
            {
                return this.Redirect("/");
            }

            var cookie = this.Request.Cookies.GetCookie(".auth-Chushka");
            cookie.Delete();
            this.Response.Cookies.Add(cookie);

            return this.Redirect("/");
        }

        [HttpGet]
        public IHttpResponse Register()
        {
            return this.View();
        }

        [HttpPost]
        public IHttpResponse Register(RegisterInputModel model)
        {
            string username = model.Username;
            string password = model.Password;
            string confirmPassword = model.ConfirmPassword;
            string fullName = model.FullName;
            string email = model.Email;

            if (string.IsNullOrWhiteSpace(username))
            {
                return this.BadRequestError("Username cannot be null or whitespace.");
            }

            if (this.Db.Users.Any(x => x.Username == username))
            {
                return this.BadRequestError("Username is already taken.");
            }

            if (password != confirmPassword)
            {
                return this.BadRequestError("Passwords do not match.");
            }

            if (string.IsNullOrWhiteSpace(fullName))
            {
                return this.BadRequestError("Full name cannot be null or whitespace");
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                return this.BadRequestError("Email cannot be null or whitespace");
            }

            if (this.Db.Users.Any(x => x.Email == email))
            {
                return this.BadRequestError("Email is already registered.");
            }

            string hashedPassword = this.hashService.Hash(password);

            var role = UserRole.User;
            if (!this.Db.Users.Any())
            {
                role = UserRole.Admin;
            }

            var user = new User()
            {
                Username = username,
                Password = hashedPassword,
                FullName = fullName,
                Email = email,
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

            return this.Redirect("/Users/Login");
        }
    }
}
