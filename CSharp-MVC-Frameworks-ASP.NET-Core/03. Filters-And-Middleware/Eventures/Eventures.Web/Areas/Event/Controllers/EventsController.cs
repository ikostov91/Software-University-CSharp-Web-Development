using Eventures.Data;
using Eventures.Models;
using Eventures.Web.Areas.Event.ViewModels;
using Eventures.Web.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Eventures.Web.Areas.Event.Controllers
{
    [Area("Event")]
    public class EventsController : Controller
    {
        private readonly IEventuresEventsService eventsService;
        private readonly ILogger<EventsController> logger;
        private readonly EventuresDbContext dbContext;
        private readonly SignInManager<EventureUser> signInManager;

        public EventsController(EventuresDbContext dbContext, 
            IEventuresEventsService eventsService, 
            ILogger<EventsController> logger,
            SignInManager<EventureUser> signInManager)
        {
            this.eventsService = eventsService;
            this.logger = logger;
            this.dbContext = dbContext;
            this.signInManager = signInManager;
        }

        [HttpGet]
        [Authorize]
        public IActionResult All()
        {
            var events = this.eventsService.All();
            var viewModels = new List<EventureEventAllEventsViewModel>();

            foreach (var eventureEvent in events.Where(e => e.TotalTickets > 0))
            {
                var eventViewModel = new EventureEventAllEventsViewModel()
                {
                    Id = eventureEvent.Id,
                    End = eventureEvent.End,
                    Start = eventureEvent.Start,
                    Name = eventureEvent.Name,
                    Place = eventureEvent.Place,
                };
                viewModels.Add(eventViewModel);
            }

            return View(viewModels);
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public IActionResult Create(EventureEventInputModel model)
        {
            eventsService.CreateEvent(model);

            return this.RedirectToAction("All", "Events", new { area = "Event" });
        }

        [HttpGet]
        [Authorize]
        public IActionResult My()
        {
            var currentUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var orders = this.eventsService.MyOrders(currentUserId);
            var viewModels = new List<EventureEventMyEventsViewModel>();

            foreach(var order in orders)
            {
                var eventureEvent = this.dbContext.EventureEvents.First(e => e.Id == order.EventId);
                var viewModel = new EventureEventMyEventsViewModel()
                {
                    End = eventureEvent.End,
                    Start = eventureEvent.Start,
                    Name = eventureEvent.Name,
                    Tickets = order.TicketsCount
                };
                viewModels.Add(viewModel);
            }

            return this.View(viewModels);
        }        
    }
}