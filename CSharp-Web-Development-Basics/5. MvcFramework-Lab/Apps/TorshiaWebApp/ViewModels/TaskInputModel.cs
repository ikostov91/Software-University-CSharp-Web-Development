using System;
using System.Collections.Generic;
using System.Text;

namespace TorshiaWebApp.ViewModels
{
    public class TaskInputModel
    {
        public string Title { get; set; }

        public string DueDate { get; set; }

        public string Description { get; set; }

        public string Participants { get; set; }

        public string Customers { get; set; }

        public string Marketing { get; set; }

        public string Finances { get; set; }

        public string Internal { get; set; }

        public string Management { get; set; }
    }
}
