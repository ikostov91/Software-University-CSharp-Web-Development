using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SoftJail.Data.Models.Attributes;

namespace SoftJail.Data.Models
{
    public class Mail
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Description { get; set; }
        
        [Required]
        public string Sender { get; set; }
        
        [Required]
        [ValidAddress]
        public string Address { get; set; }
        
        [ForeignKey("Prisoner")]
        public int PrisonerId { get; set; }
        [Required]
        public Prisoner Prisoner { get; set; }
    }
}
