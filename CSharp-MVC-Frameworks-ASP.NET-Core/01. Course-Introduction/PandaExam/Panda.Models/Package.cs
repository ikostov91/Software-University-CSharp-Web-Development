using System;
using System.ComponentModel.DataAnnotations;

namespace Panda.Models
{
    public class Package
    {
        [Key]
        public int Id { get; set; }

        public string Description { get; set; }

        public double Weight { get; set; }

        public string ShippingAddress { get; set; }

        public PackageStatus Status { get; set; } = PackageStatus.Pending;

        public DateTime? EstimatedDeliveryDate { get; set; } = null;

        public int RecipientId { get; set; }
        public virtual User Recipient { get; set; }

        public virtual Receipt Receipt { get; set; }
    }
}
