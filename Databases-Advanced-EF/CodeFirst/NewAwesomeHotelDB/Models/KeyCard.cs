using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NewAwesomeHotelD.Models
{
    public class KeyCard
    {
        [Key]
        public int Id { get; set; }

        public int CardNumber { get; set; }

        public int RoomId { get; set; }
        public virtual Room Room { get; set; }
    }
}
