using System;

namespace TorshiaWebApp.Models
{
    public class Report : BaseEntity<int>
    {
        public Status Status { get; set; }

        public DateTime ReportedOn { get; set; } = DateTime.UtcNow;

        public int TaskId { get; set; }
        public virtual Task Task { get; set; }

        public int ReporterId { get; set; }
        public virtual User Reporter { get; set; }
    }
}
