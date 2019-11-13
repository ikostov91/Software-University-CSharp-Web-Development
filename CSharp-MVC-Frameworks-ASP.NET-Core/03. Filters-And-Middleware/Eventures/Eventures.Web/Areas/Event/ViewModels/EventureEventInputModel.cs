using Eventures.Web.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace Eventures.Web.Areas.Event.ViewModels
{
    public class EventureEventInputModel
    {
        [Required]
        [MinLength(10)]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Place { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Start { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime End { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int TotalTickets { get; set; }

        [Required]
        [ValidDecimal(ErrorMessage = "Price per ticket should be a valid decimal number.")]
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal PricePerTicket { get; set; }
    }
}
