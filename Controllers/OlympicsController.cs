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
            var session = new OSession(HttpContext.Session);
            session.SetActiveGame(activeGame);
            session.SetActiveSport(activeSport);

            // if no count value in session, use data in cookie to restore fave teams in session 
            int? count = session.GetMyCountryCount();
            if (count == null)
            {
                var cookies = new OCookies(HttpContext.Request.Cookies);
                string[] ids = cookies.GetMyCountryIds();

                List<Country> mycountries = new List<Country>();
                if (ids.Length > 0)
                    mycountries = context.Countries.Include(t => t.Game)
                        .Include(t => t.Sport)
                        .Where(t => ids.Contains(t.CountryID)).ToList();
                session.SetMyCountries(mycountries);
            }

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

        

        public IActionResult Details(string id)
        {
            var session = new OSession(HttpContext.Session);
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

        [HttpPost]
        public RedirectToActionResult Add(CountryViewModel model)
        {
            model.Country = context.Countries
                .Include(t => t.Game)
                .Include(t => t.Sport)
                .Where(t => t.CountryID == model.Country.CountryID)
                .FirstOrDefault();

            var session = new OSession(HttpContext.Session);
            var teams = session.GetMyCountries();
            teams.Add(model.Country);
            session.SetMyCountries(teams);

            var cookies = new OCookies(HttpContext.Response.Cookies);
            cookies.SetMyCountryIds(teams);

            TempData["message"] = $"{model.Country.Name} added to your favorites";

            return RedirectToAction("Countries",
                new
                {
                    ActiveGame= session.GetActiveGame(),
                    ActiveSport = session.GetActiveSport()
                });
        }
    }
}
