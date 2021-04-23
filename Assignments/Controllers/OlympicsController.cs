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

        public IActionResult Countries(CountryListViewModel model)
        {
            var session = new OSession(HttpContext.Session);
            session.SetActiveGame(model.ActiveGame);
            session.SetActiveSport(model.ActiveSport);

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


            //Updated to complex model binding
            /*var data = new CountryListViewModel
            {
                ActiveGame= model.ActiveGame,
                ActiveSport = model.ActiveSport,
                Games = context.Games.ToList(),
                Sports = context.Sports.ToList()
            };*/

            model.Games = context.Games.ToList();
            model.Sports = context.Sports.ToList();

            IQueryable<Country> query = context.Countries;
            if (model.ActiveGame != "all")
                query = query.Where(
                    t => t.Game.GameID.ToLower() == model.ActiveGame.ToLower());
            if (model.ActiveSport != "all")
                query = query.Where(
                    t => t.Sport.SportID.ToLower() == model.ActiveSport.ToLower());
            model.Countries = query.ToList();

            return View(model);
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
