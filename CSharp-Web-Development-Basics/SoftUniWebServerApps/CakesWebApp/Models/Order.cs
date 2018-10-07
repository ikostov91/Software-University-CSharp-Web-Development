using System;
using System.Collections.Generic;

namespace CakesWebApp.Models
{
    public class Order : BaseModel<int>
    {
        public Order()
        {
            this.OrderProducts = new HashSet<OrderProduct>();        
        }

        public DateTime DateOfCreation { get; set; } = DateTime.UtcNow;

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<OrderProduct> OrderProducts{ get; set; }
    }
}
