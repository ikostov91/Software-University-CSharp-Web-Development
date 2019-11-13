using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChushkaWebApp.Models;
using ChushkaWebApp.ViewModels.Products;
using SIS.HTTP.Responses;
using SIS.MvcFramework;
using Type = System.Type;

namespace ChushkaWebApp.Controllers
{
    public class ProductsController : BaseController
    {
        [HttpGet]
        [Authorize(nameof(UserRole.Admin))]
        public IHttpResponse Create()
        {
            return this.View("/Products/Create");
        }

        [HttpPost]
        [Authorize(nameof(UserRole.Admin))]
        public IHttpResponse Create(ProductInputModel model)
        {
            if (!Enum.TryParse(model.Type, true, out ProductType type))
            {
                return this.BadRequestError("Invalid product type.");
            }

            var product = new Product()
            {
                Name = model.Name,
                Price = model.Price,
                Type = type,
                Description = model.Description
            };

            try
            {
                this.Db.Products.Add(product);
                this.Db.SaveChanges();
            }
            catch (Exception)
            {
                return this.ServerError("Something wrong happened.");
            }

            return this.Redirect("/");
        }

        [HttpGet]
        [Authorize]
        public IHttpResponse Details(int id)
        {
            var product = this.Db.Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return this.BadRequestError("Product not found.");
            }

            var viewModel = new ProductViewInputModel()
            {
                Id = product.Id,
                Name = product.Name,
                Type = product.Type.ToString(),
                Price = product.Price,
                Description = product.Description
            };

            return this.View("/Products/Details", viewModel);
        }

        [HttpGet]
        [Authorize(nameof(UserRole.Admin))]
        public IHttpResponse Edit(int id)
        {
            var product = this.Db.Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return this.BadRequestError("No product with such id.");
            }

            var viewModel = new ProductViewInputModel()
            {
                Id = product.Id,
                Name = product.Name,
                Type = product.Type.ToString(),
                Price = product.Price,
                Description = product.Description
            };

            return this.View("/Products/Edit", viewModel);
        }

        [HttpPost]
        [Authorize(nameof(UserRole.Admin))]
        public IHttpResponse Edit(EditProductInputModel model)
        {
            var product = this.Db.Products.FirstOrDefault(x => x.Id == model.Id);
            if (product == null)
            {
                return this.BadRequestError("No product with such id.");
            }

            if (string.IsNullOrWhiteSpace(model.Name))
            {
                return this.BadRequestError("Name cannot be null or whitespace.");
            }

            if (model.Price == 0.0m)
            {
                return this.BadRequestError("Price cannot be zero.");
            }

            if (string.IsNullOrWhiteSpace(model.Description))
            {
                return this.BadRequestError("Description cannot be null or whitespace.");
            }

            if (!Enum.TryParse(model.Type, true, out ProductType type))
            {
                return this.BadRequestError("Invalid product type.");
            }


            product.Name = model.Name;
            product.Price = model.Price;
            product.Description = model.Description;
            product.Type = type;

            try
            {
                this.Db.SaveChanges();
            }
            catch (Exception)
            {
                return this.ServerError("Something wrong happened.");
            }

            return this.Redirect("/Products/Details?id=" + product.Id);
        }

        [HttpGet]
        [Authorize(nameof(UserRole.Admin))]
        public IHttpResponse Delete(int id)
        {
            var product = this.Db.Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return this.BadRequestError("No product with such id.");
            }

            var viewModel = new ProductViewInputModel()
            {
                Id = product.Id,
                Name = product.Name,
                Type = product.Type.ToString(),
                Price = product.Price,
                Description = product.Description
            };

            return this.View("/Products/Delete", viewModel);
        }

        [HttpPost]
        [Authorize(nameof(UserRole.Admin))]
        public IHttpResponse Delete(int id, string name)
        {
            var product = this.Db.Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return this.BadRequestError("No product with such id.");
            }

            try
            {
                this.Db.Products.Remove(product);
                this.Db.SaveChanges();
            }
            catch (Exception)
            {
                return this.ServerError("Something wrong happened.");
            }

            return this.Redirect("/");
        }
    }
}
