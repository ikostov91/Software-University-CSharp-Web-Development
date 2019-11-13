using System;
using System.Collections.Generic;
using System.Text;
using ChushkaWebApp.ViewModels.Products;

namespace ChushkaWebApp.ViewModels.Home
{
    public class LoggedInIndexViewModel
    {
        public IEnumerable<ProductViewInputModel> Products { get; set; }
    }
}
