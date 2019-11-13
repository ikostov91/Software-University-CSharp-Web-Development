using Eventures.Models;
using Eventures.Data;
using System.Linq;
using Eventures.Web.Services.Contracts;
using Eventures.Web.Areas.Event.ViewModels;

namespace Eventures.Web.Services.EventureEvents
{
    public class EventuresEventsService : IEventuresEventsService
    {
        private readonly EventuresDbContext context;

        public EventuresEventsService(EventuresDbContext context)
        {
            this.context = context;
        }

        public IQueryable<EventureEvent> All() => this.context.EventureEvents;

        public IQueryable<EventureEvent> MyEvents(string userId)
        {
            return this.context.Orders.Where(o => o.UserId == userId).Select(x => x.Event);
        }

        public IQueryable<EventureOrder> MyOrders(string userId)
        {
            return this.context.Orders.Where(o => o.UserId == userId);
        }

        public void CreateEvent(EventureEventInputModel model)
        {
            var eventuresEvent = new EventureEvent()
            {
                Name = model.Name,
                Place = model.Place,
                Start = model.Start,
                End = model.End,
                TotalTickets = model.TotalTickets,
                TicketPrice = model.PricePerTicket
            };

            this.context.EventureEvents.Add(eventuresEvent);
            this.context.SaveChanges();

            return;
        }
    }
}
