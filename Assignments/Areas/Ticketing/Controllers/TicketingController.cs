using Assignments.Areas.Ticketing.Models;
using Assignments.Areas.Ticketing.Models.Repositories;
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
        private readonly ITicketRepository _repository;
        public TicketingController(ITicketRepository repository)
        {
            _repository = repository;
        }


        public IActionResult Tickets(string id)
        {
            //store current filters and data needed for filter drop downs in ToDoViewModel
            TicketViewModel model = new TicketViewModel();

            var filters = new Filters(id);

            model.Filters = new Filters(id);
            model.Statuses = _repository.GetStatuses();


           
            //Order the tickets ***
            var tickets = _repository.GetTicketsByFilter(model.Filters);

            model.Tickets = tickets;

            return View(model);
        }

        public IActionResult Add()
        {
            TicketViewModel model = new TicketViewModel();
            model.Statuses = _repository.GetStatuses();
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(TicketViewModel model)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(model.CurrentTicket);
                _repository.SaveChanges();
                return RedirectToAction("Tickets");
            }
            else
            {
                model.Statuses = _repository.GetStatuses();
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
                _repository.Remove(selected);
            }
            else
            {
                string newStatusId = selected.StatusId;
                selected = _repository.Find(selected.Id);
                selected.StatusId = newStatusId;
                _repository.Update(selected);
            }
            _repository.SaveChanges();

            return RedirectToAction("Tickets", new { ID = id });
        }
    }
}
