using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignments.Areas.Ticketing.Models
{
    public class TicketContext : DbContext
    {

        public TicketContext(DbContextOptions<TicketContext> options)
            : base(options) { }

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Status> Statuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Status>().HasData(
                new Status { StatusId = "todo", Name = "To Do" },
                new Status { StatusId = "inprogress", Name = "In progress" },
                new Status { StatusId = "qa", Name = "QA"},
                new Status { StatusId = "done", Name = "Done"}
            );
        }
    }
}
