using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore.Design;

namespace NewAwesomeHotelD.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int BedCount { get; set; }

        [Required] // Not NULL
        public int RoomNumber { get; set; }

        [DefaultValue(true)]
        public bool IsAvailable { get; set; }

        [Required]
        [NotMapped] // == Ignored
        public RoomType RoomTypeEnum => (RoomType)Enum.Parse(typeof(RoomType), this.RoomType);

        public decimal? Cost { get; set; } // Another way for an optional value

        public string RoomNickname { get; set; }

        [Required]
        public string RoomType { get; set; }

        public virtual ICollection<KeyCard> KeyCards { get; set; }
    }
}
