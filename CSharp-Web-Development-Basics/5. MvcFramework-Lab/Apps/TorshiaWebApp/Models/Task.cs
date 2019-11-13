using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TorshiaWebApp.Models
{
    public class Task : BaseEntity<int>
    {
        public Task()
        {
            this.Participants = new HashSet<TaskParticipant>();
            this.AffectedSectors = new HashSet<TaskSector>();
            this.Reports = new HashSet<Report>();
        }

        public string Title { get; set; }

        public DateTime? DueDate { get; set; } = null;

        public bool IsReported { get; set; } = false;

        public string Description { get; set; }

        [NotMapped]
        public int Level => this.AffectedSectors.Count - 1;

        public virtual ICollection<TaskParticipant> Participants { get; set; }

        public virtual ICollection<TaskSector> AffectedSectors { get; set; }

        public virtual ICollection<Report> Reports { get; set; }
}
}
