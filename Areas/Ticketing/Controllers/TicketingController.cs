using Assignments.Areas.Ticketing.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignments.Areas.Ticketing.Controllers
{
    public class TicketingController : Controller
    {
        private TicketContext context;
        public TicketingController(TicketContext ctx) => context = ctx;


        public IActionResult Tickets(string id)
        {
            //store current filters and data needed for filter drop downs in ToDoViewModel
            TicketViewModel model = new TicketViewModel();

            var filters = new Filters(id);

            model.Filters = new Filters(id);
            model.Statuses = context.Statuses.ToList();


            // get ticket objects from database based on current filters
            IQueryable<Ticket> query = context.Tickets.Include(t => t.Status);
            if (filters.HasStatus)
            {
                query = query.Where(t => t.StatusId == filters.StatusId);
            }

            //Order the tickets ***
            var tickets = query.OrderBy(t => t.Id).ToList();

            model.Tickets = tickets;

            return View(model);
        }

        public IActionResult Add()
        {
            TicketViewModel model = new TicketViewModel();
            model.Statuses = context.Statuses.ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(TicketViewModel model)
        {
            if (ModelState.IsValid)
            {
                context.Tickets.Add(model.CurrentTicket);
                context.SaveChanges();
                return RedirectToAction("Tickets");
            }
            else
            {
                model.Statuses = context.Statuses.ToList();
                return View(model);
            }
        }

        [HttpPost]
        public IActionResult Filter(string[] filter)
        {
            string id = string.Join('-', filter);
            return RedirectToAction("Tickets", new { ID = id });
        }

        [HttpPost]
        public IActionResult Edit([FromRoute] string id, Ticket selected)
        {
            if (selected.StatusId == null)
            {
                context.Tickets.Remove(selected);
            }
            else
            {
                string newStatusId = selected.StatusId;
                selected = context.Tickets.Find(selected.Id);
                selected.StatusId = newStatusId;
                context.Tickets.Update(selected);
            }
            context.SaveChanges();

            return RedirectToAction("Tickets", new { ID = id });
        }
    }
}
