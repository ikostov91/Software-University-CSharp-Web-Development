using System.Collections.Generic;

namespace CakesWebApp.ViewModels.Cakes
{
    public class SearchViewModel
    {
        public string SearchText{ get; set; }

        public List<CakeViewModel> Cakes { get; set; }
    }
}
