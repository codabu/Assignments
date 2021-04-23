using Microsoft.AspNetCore.Mvc;

using Assignments.Models;

namespace Assignments.Controllers
{
    public class FavoritesController : Controller
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
        public RedirectToActionResult Delete()
        {
            var session = new OSession(HttpContext.Session);
            var cookies = new OCookies(HttpContext.Response.Cookies);

            session.RemoveMyCountries();
            cookies.RemoveMyCountryIds();

            TempData["message"] = "Favorite countries cleared";

            return RedirectToAction("Countries", "Olympics",
                new {
                    ActiveGame = session.GetActiveGame(),
                    ActiveSport = session.GetActiveSport()
                });
        }
    }
}