using System;
using System.Collections.Generic;
using System.Text;

namespace TorshiaWebApp.Models
{
    public class TaskSector
    {
        public int Id { get; set; }

        public string Sector { get; set; }

        public int TaskId { get; set; }
        public virtual Task Task { get; set; }
    }
}
