using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CodeFirstDemoApp.POCOs
{
    public class Date
    {
        [Key]
        public int Id { get; set; }
        public DateTime SomeDate { get; set; }

        public virtual ICollection<File> Files { get; set; }
    }
}
