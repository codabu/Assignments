using System.Collections.Generic;
using System.Linq;

namespace Assignments.Areas.Ticketing.Models.Repositories
{
    public interface ITicketRepository
    {
        void Add(Ticket ticket);
        List<Status> GetStatuses();
        List<Ticket> GetTickets();
        void Remove(Ticket ticket);
        void SaveChanges();
        void Update(Ticket ticket);
        Ticket Find(int id);
        List<Ticket> GetTicketsByFilter(Filters filters);
    }
}