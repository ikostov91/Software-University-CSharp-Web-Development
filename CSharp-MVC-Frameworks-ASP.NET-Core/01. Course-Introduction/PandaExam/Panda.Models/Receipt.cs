using Panda.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Panda.Models
{
    public class Receipt
    {
        [Key]
        public int Id { get; set; }

        public decimal Fee { get; set; }

        public DateTime IssuedOn { get; set; }

        public int RecipientId { get; set; }
        public virtual User Recipient { get; set; }

        public int PackageId { get; set; }
        public virtual Package Package { get; set; }
    }
}
