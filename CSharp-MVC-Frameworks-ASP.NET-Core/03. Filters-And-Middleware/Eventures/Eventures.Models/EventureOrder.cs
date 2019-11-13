using System;
using System.Collections.Generic;
using System.Text;

namespace Eventures.Models
{
    public class EventureOrder
    {
        public int Id { get; set; }

        public DateTime OrderedOn { get; set; }

        public string EventId { get; set; }
        public EventureEvent Event { get; set; }

        public string UserId { get; set; }
        public EventureUser User { get; set; }

        public int TicketsCount { get; set; }
    }
}
