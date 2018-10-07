using System;
using CakesWebApp.Models;
using CakesWebApp.Services;
using SIS.HTTP.Cookies;

namespace CakesWebApp.Controllers
{
    using Microsoft.EntityFrameworkCore.Internal;
    using SIS.HTTP.Enums;
    using SIS.HTTP.Requests;
    using SIS.HTTP.Responses;
    using SIS.WebServer.Results;
    using System.Linq;

    public class AccountController : BaseController
    {
        private IHashService hashService;

        public AccountController()
        {
            this.hashService = new HashService();   
        }

        public IHttpResponse Register(IHttpRequest request)
        {
            return this.View("Register");
        }

        public IHttpResponse DoRegister(IHttpRequest request)
        {
            // 1. Validate!
            // 2. Generate password hash
            // 3. Create user
            // 4. redirect user to homepage

            var userName = request.FormData["username"].ToString().Trim();
            var password = request.FormData["password"].ToString();
            var confirmPassword = request.FormData["confirmPassword"].ToString();

            // 1.Validate
            if (string.IsNullOrWhiteSpace(userName) || userName.Length < 4)
            {
                return this.BadRequestError("Please provide valid username with length of 4 or more characters.");
            }

            if (this.Db.Users.Any(x => x.Username == userName))
            {
                return this.BadRequestError("User with same name already exists.");
            }

            if (string.IsNullOrWhiteSpace(password) || password.Length < 6)
            {
                return this.BadRequestError("Please provide valid password of length 6 or more characters.");
            }

            if (password != confirmPassword)
            {
                return this.BadRequestError("Passwords do not match.");
            }

            // 2.Generate password hash
            var hashedPassword = this.hashService.Hash(password);

            // 3.Create user
            var user = new User()
            {
                Name = userName,
                Username = userName,
                Password = hashedPassword
            };

            try
            {
                this.Db.Users.Add(user);
                this.Db.SaveChanges();
            }
            catch (Exception e)
            {
                // TODO: Log error
                return this.ServerError(e.Message);
            }

            // TODO: Login

            return new RedirectResult("/");
        }

        public IHttpResponse Login(IHttpRequest request)
        {
            return this.View("Login");
        }

        public IHttpResponse DoLogin(IHttpRequest request)
        {
            // 1.Validate user
            // 2. Save cookie/session with the user
            // Redirect

            // 1.Validate
            var username = request.FormData["username"].ToString().Trim();
            var password = request.FormData["password"].ToString();

            var hashedPassword = this.hashService.Hash(password);

            var user = this.Db.Users.FirstOrDefault(x => x.Username == username && x.Password == hashedPassword);

            if (user == null)
            {
                return this.BadRequestError("Invalid username or password.");
            }

            // 2.Save cookie/session
            var cookieContent = this.UserCookieService.GetUserCookie(user.Username);

            // Add "remember me" to login page
            var response = new RedirectResult("/");
            response.Cookies.Add(new HttpCookie(".auth-cakes", cookieContent, 7));

            return response;
        }

        public IHttpResponse Logout(IHttpRequest request)
        {
            if (!request.Cookies.ContainsCookie(".auth-cakes"))
            {
                return new RedirectResult("/");
            }

            var cookie = request.Cookies.GetCookie(".auth-cakes");
            cookie.Delete();
            var response = new RedirectResult("/");
            response.Cookies.Add(cookie);

            return response;
        }
    }
}
