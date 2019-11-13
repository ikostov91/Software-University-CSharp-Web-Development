using Microsoft.AspNetCore.Mvc;
using FDMC.Web.Models;

namespace FDMC.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
