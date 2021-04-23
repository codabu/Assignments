using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignments.Areas.Ticketing.Models
{
    public class TicketViewModel
    {
        public TicketViewModel()
        {
            CurrentTicket = new Ticket();
        }
        public Filters Filters { get; set; }
        public List<Status> Statuses { get; set; }

        public List<Ticket> Tickets { get; set; }

        public Ticket CurrentTicket { get; set; }  //used for Add
    }
}
