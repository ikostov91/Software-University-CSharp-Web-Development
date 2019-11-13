using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore.Migrations;
using PandaWebApp.ViewModels;
using SIS.HTTP.Responses;
using SIS.MvcFramework;

namespace PandaWebApp.Controllers
{
    public class ReceiptsController : BaseController
    {
        [HttpGet]
        [Authorize]
        public IHttpResponse Index()
        {
            var viewModel = new ReceiptsViewModel()
            {
                Receipts = this.Db.Receipts
                    .Where(x => x.Recipient.Username == this.User.Username)
                    .Select(x => new ReceiptViewModel()
                    {
                        Id = x.Id,
                        Fee = x.Fee,
                        IssuedOn = x.IssuedOn.ToString("dd/MM/yyyy"),
                        Recipient = x.Recipient.Username
                    })
            };

            return this.View(viewModel);
        }

        [HttpGet]
        [Authorize]
        public IHttpResponse Details(int id)
        {
            var receipt = this.Db.Receipts.FirstOrDefault(x => x.Id == id);
            if (receipt == null)
            {
                return this.BadRequestError("Receipt not found.");
            }

            var viewModel = new ReceiptDetailsViewModel()
            {
                DeliveryAddress = receipt.Package.ShippingAddress,
                Fee = receipt.Fee,
                Id = receipt.Id,
                IssuedOn = receipt.IssuedOn.ToString("dd/MM/yyyy"),
                PackageDescription = receipt.Package.Description,
                PackageWeight = receipt.Package.Weight,
                Recipient = receipt.Recipient.Username
            };

            return this.View(viewModel);
        }
    }
}
