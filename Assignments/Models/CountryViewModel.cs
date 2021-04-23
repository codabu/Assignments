using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignments.Models
{
    public class CountryViewModel
    {
        public Country Country { get; set; }
        public string ActiveGame { get; set; } = "all"; // set the default value for complex model binding
        public string ActiveSport { get; set; } = "all"; //set the default value for complex model binding
    }
}
