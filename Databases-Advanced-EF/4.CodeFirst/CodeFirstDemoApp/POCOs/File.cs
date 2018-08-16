using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CodeFirstDemoApp.POCOs
{
    public class File
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Extension { get; set; }
        [Required]
        public byte[] Content { get; set; }

        [Required]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<Date> Dates { get; set; }
    }
}
