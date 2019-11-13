using Eventures.Models;
using Eventures.Services.Web.EventureEvents.Contracts;
using Eventures.Data;
using System.Linq;

namespace Eventures.Services.Web.EventureEvents
{
    public class EventuresEventsService : IEventuresEventsService
    {
        private readonly EventuresDbContext context;

        public EventuresEventsService(EventuresDbContext context)
        {
            this.context = context;
        }

        public IQueryable<EventureEvent> All() => this.context.EventureEvents;

        //public void CreateEvent(EventureEventViewModel model)
        //{
        //    var eventuresEvent = new EventureEvent()
        //    {
        //        Name = model.Name,
        //        Place = model.Place,
        //        Start = model.Start,
        //        End = model.End,
        //        TotalTickets = model.TotalTickets,
        //        TicketPrice = model.PricePerTicket
        //    };

        //    return;
        //}
    }
}
