using System.Collections.Generic;

namespace ChushkaWebApp.ViewModels.Products
{
    public class AllOrdersViewModel
    {
        public IEnumerable<OrderViewModel> Orders { get; set; }
    }
}
