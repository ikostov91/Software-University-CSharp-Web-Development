using Eventures.Models;
//using Eventures.Web.Areas.Event.ViewModels;
using System.Linq;

namespace Eventures.Services.Web.EventureEvents.Contracts
{
    public interface IEventuresEventsService
    {
        IQueryable<EventureEvent> All();

        //void CreateEvent(EventureEventViewModel model);
    }
}
