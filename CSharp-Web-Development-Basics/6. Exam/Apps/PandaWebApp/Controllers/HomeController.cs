using System.Linq;
using PandaWebApp.Models;
using PandaWebApp.ViewModels;

namespace PandaWebApp.Controllers
{
    using SIS.HTTP.Responses;
    using SIS.MvcFramework;

    public class HomeController : BaseController
    {
        [HttpGet]
        public IHttpResponse Index()
        {
            if (this.User.IsLoggedIn)
            {
                var viewModel = new IndexViewModel()
                {
                    Pending = this.Db.Packages
                        .Where(x => x.Status == PackageStatus.Pending && x.Recipient.Username == this.User.Username)
                        .Select(x => new IndexPackageViewModel()
                        {
                            Id = x.Id,
                            Description = x.Description
                        }),
                    Shipped = this.Db.Packages
                        .Where(x => x.Status == PackageStatus.Shipped && x.Recipient.Username == this.User.Username)
                        .Select(x => new IndexPackageViewModel()
                        {
                            Id = x.Id,
                            Description = x.Description
                        }),
                    Delivered = this.Db.Packages
                        .Where(x => x.Status == PackageStatus.Delivered && x.Recipient.Username == this.User.Username)
                        .Select(x => new IndexPackageViewModel()
                        {
                            Id = x.Id,
                            Description = x.Description
                        })
                };

                return this.View("/Home/LoggedInIndex", viewModel);
            }

            return this.View("/Home/Index");
        }
    }
}
