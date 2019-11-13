using Microsoft.AspNetCore.Mvc;

namespace Panda.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
