using Eventures.Models;
using Eventures.Web.Areas.Event.ViewModels;
using System.Linq;

namespace Eventures.Web.Services.Contracts
{
    public interface IEventuresEventsService
    {
        IQueryable<EventureEvent> All();

        void CreateEvent(EventureEventInputModel model);

        IQueryable<EventureEvent> MyEvents(string userId);

        IQueryable<EventureOrder> MyOrders(string userId);
    }
}
