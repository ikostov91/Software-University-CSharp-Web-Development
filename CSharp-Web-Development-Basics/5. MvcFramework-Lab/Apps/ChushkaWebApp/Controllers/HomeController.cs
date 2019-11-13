using System.Linq;
using ChushkaWebApp.ViewModels.Home;
using ChushkaWebApp.ViewModels.Products;
using SIS.HTTP.Responses;
using SIS.MvcFramework;

namespace ChushkaWebApp.Controllers
{
    public class HomeController : BaseController
    {
        [HttpGet]
        public IHttpResponse Index()
        {
            if (this.User.IsLoggedIn)
            {
                //var orderProductIds = this.Db.Orders.Select(x => x.Product.Id);

                var viewModel = new LoggedInIndexViewModel()
                {
                    //Products = this.Db.Products.Where(x => !orderProductIds.Contains(x.Id)).Select(x => new ProductViewModel()
                    Products = this.Db.Products.Select(x => new ProductViewInputModel()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Type = x.Type.ToString(),
                        Price = x.Price,
                        Description = x.Description.Length > 50 ? x.Description.Substring(0, 50) + "..." : x.Description
                    }).ToList()
                };

                return this.View("/Home/LoggedInIndex", viewModel);
            }

            return this.View("/Home/Index");
        }
    }
}
