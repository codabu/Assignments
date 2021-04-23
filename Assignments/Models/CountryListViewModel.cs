using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignments.Models
{
    public class CountryListViewModel : CountryViewModel
    {
        public String UserName { get; set; }
        public List<Country> Countries { get; set; }

        // use full properties for Games and Sports
        // so can add 'All' item at beginning
        private List<Game> games;
        public List<Game> Games
        {
            get => games;
            set
            {
                //games = value;
                //games.Insert(0,
                //    new Game { GameID = "all", Name = "All" });
                games = new List<Game> {
                    new Game { GameID = "all", Name = "All" }
                };
                games.AddRange(value);
            }
        }

        private List<Sport> sports;
        public List<Sport> Sports
        {
            get => sports;
            set
            {
                //sports = value;
                //sports.Insert(0,
                //    new Sport { SportID = "all", Name = "All" });
                sports = new List<Sport> {
                    new Sport { SportID = "all", Name = "All" }
                };
                sports.AddRange(value);
            }
        }

        // methods to help view determine active link
        public string CheckActiveGame(string c) =>
            c.ToLower() == ActiveGame.ToLower() ? "active" : "";

        public string CheckActiveSport(string d) =>
            d.ToLower() == ActiveSport.ToLower() ? "active" : "";
    }
}