using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using SIS.HTTP.Responses;
using SIS.MvcFramework;
using TorshiaWebApp.Models;
using TorshiaWebApp.ViewModels;

namespace TorshiaWebApp.Controllers
{
    public class TasksController : BaseController
    {
        [HttpGet]
        [Authorize(nameof(UserRole.Admin))]
        public IHttpResponse Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize(nameof(UserRole.Admin))]
        public IHttpResponse Create(TaskInputModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Title))
            {
                return this.BadRequestError("Invalid title.");
            }

            if (!DateTime.TryParse(model.DueDate, out DateTime dueDate))
            {
                return this.BadRequestError("Date is invalid.");
            }

            if (dueDate < DateTime.Now)
            {
                return this.BadRequestError("Due Date cannot be before current date.");
            }

            if (string.IsNullOrWhiteSpace(model.Description))
            {
                return this.BadRequestError("Description is invalid.");
            }

            var participants = model.Participants.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries).ToList();

            var affectedSectors = new List<string>();
            affectedSectors.Add(model.Customers);
            affectedSectors.Add(model.Marketing);
            affectedSectors.Add(model.Finances);
            affectedSectors.Add(model.Internal);
            affectedSectors.Add(model.Management);

            var task = new Task()
            {
                Title = model.Title,
                Description = model.Description,
                DueDate = dueDate,
                Participants = participants.Select(x => new TaskParticipant()
                {
                    Participant = x
                }).ToList()
            };

            foreach (var sectorString in affectedSectors)
            {
                var parsed = Enum.TryParse(sectorString, true, out Sector sector);

                if (parsed)
                {
                    var taskSector = new TaskSector()
                    {
                        Sector = sector.ToString(),
                        TaskId = task.Id,
                        Task = task
                    };
                    task.AffectedSectors.Add(taskSector);
                }
            }

            try
            {
                this.Db.Tasks.Add(task);
                this.Db.SaveChanges();
            }
            catch (Exception)
            {
                return this.BadRequestError("Something wrong happened.");
            }

            return this.Redirect("/");
        }
    }
}
