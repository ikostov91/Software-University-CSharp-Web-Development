using System;
using System.Collections.Generic;
using System.Text;
using PandaWebApp.Models;

namespace PandaWebApp.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<IndexPackageViewModel> Pending { get; set; }

        public IEnumerable<IndexPackageViewModel> Shipped { get; set; }

        public IEnumerable<IndexPackageViewModel> Delivered { get; set; }
    }
}
