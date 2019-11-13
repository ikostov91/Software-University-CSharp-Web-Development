using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FDMC.Web.Models;
using FDMC.Web.Data;

namespace FDMC.Web.Controllers
{
    public class HomeController : Controller
    {
        private FdmcDbContext context;

        public HomeController(FdmcDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            //this.context.Users.All(x => x.UserName == "dsa");
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
