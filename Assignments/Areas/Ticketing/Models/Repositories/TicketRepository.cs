using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignments.Areas.Ticketing.Models.Repositories
{

    public class TicketRepository : ITicketRepository
    {
        private readonly TicketContext _context;

        public TicketRepository(TicketContext context)
        {
            _context = context;
        }

        public List<Ticket> GetTickets()
        {
            return _context.Tickets.ToList();
        }

        public List<Status> GetStatuses()
        {
            return _context.Statuses.ToList();
        }

        public void Add(Ticket ticket)
        {
            _context.Tickets.Add(ticket);
        }

        public void Update(Ticket ticket)
        {
            _context.Update(ticket);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Remove(Ticket ticket)
        {
            _context.Remove(ticket);
        }

        public Ticket Find (int TicketId)
        {
            return _context.Find<Ticket>(TicketId);
        }

        public List<Ticket> GetTicketsByFilter(Filters filters)
        {
            //Get ticket objects from database based on current filters
            IQueryable<Ticket> query = _context.Tickets.Include(t => t.Status);
            if (filters.HasStatus)
            {
                query = query.Where(t => t.StatusId == filters.StatusId);
            }

            //Order the tickets
            return query.OrderBy(t => t.Id).ToList();
        }
    }
}
