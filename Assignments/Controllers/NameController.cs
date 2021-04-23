using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignments.Models;

namespace Assignments.Controllers
{
    public class NameController : Controller
    {
        [HttpGet]
        public ViewResult Countries()
        {
            var session = new OSession(HttpContext.Session);
            var model = new CountryListViewModel
            {
                ActiveGame = session.GetActiveGame(),
                ActiveSport = session.GetActiveSport(),
                Countries = session.GetMyCountries(),
                UserName = session.GetName()
            };

            return View(model);
        }

        [HttpPost]
        public RedirectToActionResult Change(CountryListViewModel model)
        {
            var session = new OSession(HttpContext.Session);
            session.SetName(model.UserName);
            return RedirectToAction("Countries", "Olympics", new
            {
                ActiveGame = session.GetActiveGame(),
                ActiveSport = session.GetActiveSport()
            });
        }
    }
}
