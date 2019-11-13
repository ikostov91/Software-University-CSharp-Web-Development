using Eventures.Data;
using Eventures.Models;
using Eventures.Web.Areas.Order.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Eventures.Web.Areas.Order.Controllers
{
    [Area("Order")]
    public class OrdersController : Controller
    {
        private readonly EventuresDbContext dbContext;
        private readonly UserManager<EventureUser> userManager;

        public OrdersController(EventuresDbContext dbContext,
            UserManager<EventureUser> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        [HttpPost]
        [Authorize]
        public IActionResult OrderEvent(string eventId, int totalTickets)
        {
            if (totalTickets < 0 || !this.dbContext.EventureEvents.Any(e => e.Id == eventId))
            {
                return this.RedirectToAction("BadRequest", "Errors", new { area = "" });
            }

            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var eventureEvent = this.dbContext.EventureEvents.First(e => e.Id == eventId);
            if (eventureEvent.TotalTickets < totalTickets)
            {
                TempData["ErrorMessage"] = "Not enough tickets available.";
                return this.RedirectToAction("Error", "Errors", new { area = "" });
            }

            var order = new EventureOrder()
            {
                OrderedOn = DateTime.UtcNow,
                EventId = eventId,
                Event = this.dbContext.EventureEvents.First(e => e.Id == eventId),
                UserId = userId,
                User = this.dbContext.Users.First(u => u.Id == userId),
                TicketsCount = totalTickets
            };

            eventureEvent.TotalTickets -= totalTickets;
            this.dbContext.Orders.Add(order);
            this.dbContext.SaveChanges();

            return this.RedirectToAction("My", "Events", new { area = "Event" });
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public IActionResult All()
        {
            var orders = this.dbContext.Orders;

            var viewModels = new List<EventureOrderAllOrdersViewModel>();

            foreach (var order in orders)
            {
                var eventureEvent = this.dbContext.EventureEvents.First(x => x.Id == order.EventId).Name;
                var customer = this.dbContext.Users.First(x => x.Id == order.UserId).UserName;

                var viewModel = new EventureOrderAllOrdersViewModel()
                {
                    Event = eventureEvent,
                    Customer = customer,
                    OrderedOn = order.OrderedOn
                };
                viewModels.Add(viewModel);
            }

            return this.View(viewModels);
        }
    }
}
