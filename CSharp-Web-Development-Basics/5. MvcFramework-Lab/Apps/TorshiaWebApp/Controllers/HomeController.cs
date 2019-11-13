using System.Linq;
using SIS.HTTP.Responses;
using SIS.MvcFramework;
using TorshiaWebApp.ViewModels;

namespace TorshiaWebApp.Controllers
{
    public class HomeController : BaseController
    {
        [HttpGet]
        public IHttpResponse Index()
        {
            var viewModel = new IndexViewModel()
            {
                Tasks = this.Db.Tasks.Select(x => new TaskViewModel()
                {
                    Id = x.Id,
                    Name = x.Title,
                    Level = x.Level
                }).ToList()
            };

            return this.View(viewModel);
        }
    }
}
