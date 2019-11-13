using System;
using System.Collections.Generic;
using System.Text;

namespace TorshiaWebApp.ViewModels
{
    public class IndexViewModel
    {
        public ICollection<TaskViewModel> Tasks { get; set; }
    }
}
