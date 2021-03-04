using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Assignments.Models;

namespace Assignments.Controllers
{
    public class OlympicsController : Controller
    {
        private CountryContext context;

        public OlympicsController(CountryContext ctx)
        {
            context = ctx;
        }

        public IActionResult Countries(string activeGame = "all",
                                   string activeSport = "all")
        {
            var data = new CountryListViewModel
            {
                ActiveGame= activeGame,
                ActiveSport = activeSport,
                Games = context.Games.ToList(),
                Sports = context.Sports.ToList()
            };

            IQueryable<Country> query = context.Countries;
            if (activeGame != "all")
                query = query.Where(
                    t => t.Game.GameID.ToLower() == activeGame.ToLower());
            if (activeSport != "all")
                query = query.Where(
                    t => t.Sport.SportID.ToLower() == activeSport.ToLower());
            data.Countries = query.ToList();

            return View(data);
        }

        [HttpPost]
        public IActionResult Details(CountryViewModel model)
        {
            //Utility.LogCountryClick(model.Country.CountryID);

            TempData["ActiveGame"] = model.ActiveGame;
            TempData["ActiveSport"] = model.ActiveSport;
            return RedirectToAction("Details", new { ID = model.Country.CountryID });
        }

        [HttpGet]
        public IActionResult Details(string id)
        {
            var model = new CountryViewModel
            {
                Country = context.Countries
                    .Include(t => t.Game)
                    .Include(t => t.Sport)
                    .FirstOrDefault(t => t.CountryID == id),
                ActiveGame = TempData?["ActiveGame"]?.ToString() ?? "all",
                ActiveSport = TempData?["ActiveSport"]?.ToString() ?? "all"
            };
            return View(model);
        }
    }
}
