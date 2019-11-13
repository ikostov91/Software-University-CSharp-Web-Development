using Eventures.Web.Services.EventureEvents;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Eventures.Web.Filters
{
    public class LogUserActivityActionFilter : ActionFilterAttribute
    {
        private readonly EventuresEventsService eventsService;

        public LogUserActivityActionFilter(EventuresEventsService eventsService)
        {
            this.eventsService = eventsService;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var user = context.HttpContext.User.Identity.Name;
            base.OnActionExecuting(context);
            ////string message = $"[{DateTime.UtcNow}] Administrator {0} create event {1} {2}/{3}";
        }
    }
}
