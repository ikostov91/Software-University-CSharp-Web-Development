using System;
using System.ComponentModel.DataAnnotations;

namespace ChushkaWebApp.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public DateTime OrderedOn { get; set; } = DateTime.UtcNow;
    }
}
