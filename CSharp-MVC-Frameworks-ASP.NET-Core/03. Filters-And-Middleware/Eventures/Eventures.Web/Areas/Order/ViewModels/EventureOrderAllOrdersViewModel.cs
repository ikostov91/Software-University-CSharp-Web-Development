using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventures.Web.Areas.Order.ViewModels
{
    public class EventureOrderAllOrdersViewModel
    {
        public string Event { get; set; }

        public string Customer { get; set; }

        public DateTime OrderedOn { get; set; }
    }
}
