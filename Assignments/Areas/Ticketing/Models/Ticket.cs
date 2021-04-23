using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignments.Areas.Ticketing.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a ticket name.")]
        [MaxLength(40, ErrorMessage ="Please enter a shorter name (max 40 characters) use the description field for additional info")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a description.")]
        [MaxLength(250, ErrorMessage = "Please enter a shorter description, max 250 characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter a sprint number")]
        [Range(0, 100, ErrorMessage = "Please enter a value between 0 and 10")]
        public int SprintNumber{ get; set; }

        [Required(ErrorMessage = "Please enter a point value")]
        [Range(1, 10, ErrorMessage = "Please enter a value between 0 and 10")]
        public int PointValue { get; set; }

        [Required(ErrorMessage = "Please select a status.")]
        public string StatusId { get; set; }
        public Status Status { get; set; }
    }
}
