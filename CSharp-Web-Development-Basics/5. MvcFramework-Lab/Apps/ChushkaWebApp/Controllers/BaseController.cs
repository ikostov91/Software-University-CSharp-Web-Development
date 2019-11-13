using SIS.MvcFramework;
using ChushkaWebApp.Data;

namespace ChushkaWebApp.Controllers
{
    public abstract class BaseController : Controller
    {
        public BaseController()
        {
            this.Db = new ChushkaDbContext();
        }

        public ChushkaDbContext Db { get; }
    }
}
