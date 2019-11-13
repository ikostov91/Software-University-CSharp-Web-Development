using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;
using TorshiaWebApp.Data;

namespace TorshiaWebApp.Controllers
{
    public abstract class BaseController : Controller
    {
        public BaseController()
        {
            this.Db = new TorshiaDbContext();
        }

        public TorshiaDbContext Db { get; }
    }
}
