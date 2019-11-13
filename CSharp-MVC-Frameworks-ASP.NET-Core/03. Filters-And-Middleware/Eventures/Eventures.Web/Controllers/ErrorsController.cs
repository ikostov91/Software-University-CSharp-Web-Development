using Microsoft.AspNetCore.Mvc;

namespace Eventures.Web.Controllers
{
    public class ErrorsController : Controller
    {    
        [HttpGet]
        public IActionResult Error()
        {
            return this.View();
        }
    }
}
