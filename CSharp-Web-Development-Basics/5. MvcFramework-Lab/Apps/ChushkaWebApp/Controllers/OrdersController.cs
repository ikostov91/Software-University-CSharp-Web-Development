using ChushkaWebApp.Models;
using ChushkaWebApp.ViewModels.Products;
using SIS.HTTP.Responses;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChushkaWebApp.Controllers
{
    public class OrdersController : BaseController
    {
        [HttpGet]
        [Authorize]
        public IHttpResponse Order(int id)
        {
            var user = this.Db.Users.FirstOrDefault(x => x.Username == this.User.Username);
            if (user == null)
            {
                return this.BadRequestError("Invalid user.");
            }

            var product = this.Db.Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return this.BadRequestError("No product with such id.");
            }

            var order = new Order()
            {
                ProductId = product.Id,
                Product = product,
                UserId = user.Id,
                User = user
            };

            try
            {
                this.Db.Orders.Add(order);
                this.Db.SaveChanges();
            }
            catch (Exception)
            {
                return this.ServerError("Something wrong happened");
            }

            return this.Redirect("/");
        }

        [HttpGet]
        [Authorize(nameof(UserRole.Admin))]
        public IHttpResponse All()
        {
            var viewModel = new AllOrdersViewModel()
            {
                Orders = this.Db.Orders.Select(x => new OrderViewModel()
                {
                    Id = x.Id,
                    Customer = x.User.FullName,
                    Product = x.Product.Name,
                    OrderedOn = x.OrderedOn.ToString("hh:mm dd/MM/yyyy")
                })
            };

            return this.View("/Orders/All", viewModel);
        }
    }
}
