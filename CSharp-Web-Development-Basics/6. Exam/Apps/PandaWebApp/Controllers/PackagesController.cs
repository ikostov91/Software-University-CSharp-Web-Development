using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PandaWebApp.Models;
using PandaWebApp.ViewModels;
using SIS.HTTP.Responses;
using SIS.MvcFramework;

namespace PandaWebApp.Controllers
{
    public class PackagesController : BaseController
    {
        private const double FeeMultiplier = 2.67;

        [HttpGet]
        [Authorize(nameof(UserRole.Admin))]
        public IHttpResponse Create()
        {
            var viewModel = new RecipientsViewModel()
            {
                Recipients = this.Db.Users.Select(x => new RecipientViewModel()
                {
                    Id = x.Id,
                    Name = x.Username
                }).ToList()
            };

            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize(nameof(UserRole.Admin))]
        public IHttpResponse Create(CreatePackageInputModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Description))
            {
                return this.BadRequestError("Invalid description.");
            }

            if (model.Weight <= 0)
            {
                return this.BadRequestError("Invalid weight.");
            }

            if (string.IsNullOrWhiteSpace(model.ShippingAddress))
            {
                return this.BadRequestError("Invalid shipping address.");
            }

            var user = this.Db.Users.FirstOrDefault(x => x.Id == model.UserId);
            if (user == null)
            {
                return this.BadRequestError("Invalid user.");
            }

            var package = new Package()
            {
                Description = model.Description,
                Weight = model.Weight,
                ShippingAddress = model.ShippingAddress,
                RecipientId = model.UserId,
                Recipient = user
            };

            try
            {
                this.Db.Packages.Add(package);
                this.Db.SaveChanges();
            }
            catch (Exception)
            {
                return this.ServerError("Error.");
            }

            return this.Redirect("/");
        }

        [HttpGet]
        [Authorize]
        public IHttpResponse Details(int id)
        {
            var package = this.Db.Packages.FirstOrDefault(x => x.Id == id);
            if (package == null)
            {
                return this.BadRequestError("Package not found.");
            }

            var viewModel = new DetailsPackageViewModel()
            {
                Description = package.Description,
                EstimatedDeliveryDate = package.EstimatedDeliveryDate != null ? package.EstimatedDeliveryDate.Value.ToString("dd/MM/yyyy") : "N/A",
                Recipient = package.Recipient.Username,
                ShippingAddress = package.ShippingAddress,
                Status = package.Status.ToString(),
                Weight = package.Weight
            };

            return this.View(viewModel);
        }

        [HttpGet]
        [Authorize(nameof(UserRole.Admin))]
        public IHttpResponse Pending()
        {
            var viewModel = new AdminPackagesViewModel()
            {
                Packages = this.Db.Packages.Where(x => x.Status == PackageStatus.Pending)
                    .Select(x => new AdminPackageViewModel()
                    {
                        Id = x.Id,
                        Description = x.Description,
                        Recipient = x.Recipient.Username,
                        ShippingAddress = x.ShippingAddress,
                        Weight = x.Weight
                    })
            };

            return this.View(viewModel);
        }

        [HttpGet]
        [Authorize(nameof(UserRole.Admin))]
        public IHttpResponse Ship(int id)
        {
            var package = this.Db.Packages.FirstOrDefault(x => x.Id == id);
            if (package == null)
            {
                return this.BadRequestError("Package not found.");
            }

            package.Status = PackageStatus.Shipped;
            var currentDate = DateTime.UtcNow;
            Random rnd = new Random();
            int days = rnd.Next(20, 40);
            package.EstimatedDeliveryDate = currentDate.AddDays(days);

            try
            {
                this.Db.SaveChanges();
            }
            catch (Exception e)
            {
                return this.ServerError("Error.");
            }

            return this.Redirect("/packages/pending");
        }

        [HttpGet]
        [Authorize(nameof(UserRole.Admin))]
        public IHttpResponse Shipped()
        {
            var viewModel = new AdminPackagesViewModel()
            {
                Packages = this.Db.Packages.Where(x => x.Status == PackageStatus.Shipped)
                    .Select(x => new AdminPackageViewModel()
                    {
                        Id = x.Id,
                        Description = x.Description,
                        Recipient = x.Recipient.Username,
                        ShippingAddress = x.ShippingAddress,
                        Weight = x.Weight
                    })
            };

            return this.View(viewModel);
        }

        [HttpGet]
        [Authorize(nameof(UserRole.Admin))]
        public IHttpResponse Deliver(int id)
        {
            var package = this.Db.Packages.FirstOrDefault(x => x.Id == id);
            if (package == null)
            {
                return this.BadRequestError("Package not found.");
            }

            package.Status = PackageStatus.Delivered;

            try
            {
                this.Db.SaveChanges();
            }
            catch (Exception e)
            {
                return this.ServerError("Error.");
            }

            return this.Redirect("/packages/shipped");
        }

        [HttpGet]
        [Authorize(nameof(UserRole.Admin))]
        public IHttpResponse Delivered()
        {
            var viewModel = new AdminPackagesViewModel()
            {
                Packages = this.Db.Packages.Where(x => x.Status == PackageStatus.Delivered || x.Status == PackageStatus.Acquired)
                    .Select(x => new AdminPackageViewModel()
                    {
                        Id = x.Id,
                        Description = x.Description,
                        Recipient = x.Recipient.Username,
                        ShippingAddress = x.ShippingAddress,
                        Weight = x.Weight
                    })
            };

            return this.View(viewModel);
        }

        [HttpGet]
        [Authorize]
        public IHttpResponse Acquire(int id)
        {
            var package = this.Db.Packages.FirstOrDefault(x => x.Id == id);
            if (package == null)
            {
                return this.BadRequestError("Package not found.");
            }

            var user = this.Db.Users.First(x => x.Username == this.User.Username);

            package.Status = PackageStatus.Acquired;
            var receipt = new Receipt()
            {
                Fee = (decimal)(package.Weight * FeeMultiplier),
                IssuedOn = DateTime.UtcNow,
                RecipientId = user.Id,
                Recipient = user,
                PackageId = package.Id,
                Package = package
            };

            try
            {
                this.Db.Receipts.Add(receipt);
                this.Db.SaveChanges();
            }
            catch (Exception e)
            {
                return this.BadRequestError("Error.");
            }

            return this.Redirect("/");
        }
    }
}
