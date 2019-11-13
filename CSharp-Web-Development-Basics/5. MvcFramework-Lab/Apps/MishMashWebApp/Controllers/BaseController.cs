using SIS.MvcFramework;
using MishMashWebApp.Data;

namespace MishMashWebApp.Controllers
{
    public abstract class BaseController : Controller
    {
        public BaseController()
        {
            this.Db = new ApplicationDbContext();
        }

        protected ApplicationDbContext Db { get; }
    }
}
