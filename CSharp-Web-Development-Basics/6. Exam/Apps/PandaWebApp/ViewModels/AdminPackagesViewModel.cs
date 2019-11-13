using System;
using System.Collections.Generic;
using System.Text;

namespace PandaWebApp.ViewModels
{
    public class AdminPackagesViewModel
    {
        public IEnumerable<AdminPackageViewModel> Packages { get; set; }
    }
}
