using Assignments.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignments.Controllers
{
    public class Assignment6_1Controller : Controller
    {
        [Route("Assigntment6_1/Module5/{id}")]
        public IActionResult Module5(int id)
        {
            ViewModel view = new ViewModel(id);
            return View(view);
        }
    }
}
