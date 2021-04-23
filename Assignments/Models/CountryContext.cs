using Microsoft.EntityFrameworkCore;

namespace Assignments.Models
{
    public class CountryContext : DbContext
    {
        public CountryContext(DbContextOptions<CountryContext> options)
            : base(options)
        { }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Sport> Sports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Game>().HasData(
                new Game { GameID = "wo", Name = "Winter Olympics" },
                new Game { GameID = "so", Name = "Summer Olympics" },
                new Game { GameID = "p", Name = "Paralympics" },
                new Game { GameID = "yo", Name = "Youth Olympic Games" }
            );
            modelBuilder.Entity<Sport>().HasData(
                new Sport { SportID = "curl", Name = "Curling/Indoor" },
                new Sport { SportID = "bobs", Name = "Bobsleigh/Outdoor" },
                new Sport { SportID = "dive", Name = "Diving/Indoor" },
                new Sport { SportID = "cycl", Name = "Road Cycling/Outdoor" },
                new Sport { SportID = "arch", Name = "Archery/Indoor" },
                new Sport { SportID = "cano", Name = "Canoe Sprint/Outdoor" },
                new Sport { SportID = "brea", Name = "Breakdancing/Indoor" },
                new Sport { SportID = "skat", Name = "Skateboarding/Outdoor" }
            );
            modelBuilder.Entity<Country>().HasData(
                new { CountryID = "aus", Name = "Austria", GameID = "p", SportID = "cano", LogoImage = "austria.png" },
                new { CountryID = "bra", Name = "Brazil", GameID = "so", SportID = "cycl", LogoImage = "brazil.png" },
                new { CountryID = "can", Name = "Canada", GameID = "wo", SportID = "curl", LogoImage = "canada.png" },
                new { CountryID = "chi", Name = "China", GameID = "so", SportID = "dive", LogoImage = "china.png" },
                new { CountryID = "cyp", Name = "Cyprus", GameID = "yo", SportID = "brea", LogoImage = "cyprus.png" },
                new { CountryID = "fin", Name = "Finland", GameID = "yo", SportID = "skat", LogoImage = "finland.png" },
                new { CountryID = "fra", Name = "France", GameID = "yo", SportID = "brea", LogoImage = "france.png" },
                new { CountryID = "ger", Name = "Germany", GameID = "so", SportID = "dive", LogoImage = "germany.png" },
                new { CountryID = "ita", Name = "Italy", GameID = "wo", SportID = "bobs", LogoImage = "italy.png" },
                new { CountryID = "jam", Name = "Jamaica", GameID = "wo", SportID = "bobs", LogoImage = "jamaica.png" },
                new { CountryID = "jap", Name = "Japan", GameID = "wo", SportID = "bobs", LogoImage = "japan.png" },
                new { CountryID = "mex", Name = "Mexico", GameID = "so", SportID = "dive", LogoImage = "mexico.png" },
                new { CountryID = "net", Name = "Netherlands", GameID = "so", SportID = "cycl", LogoImage = "netherlands.png" },
                new { CountryID = "pak", Name = "Pakistan", GameID = "p", SportID = "cano", LogoImage = "pakistan.png" },
                new { CountryID = "por", Name = "Portugal", GameID = "yo", SportID = "skat", LogoImage = "portugal.png" },
                new { CountryID = "rus", Name = "Russia", GameID = "yo", SportID = "brea", LogoImage = "russia.png" },
                new { CountryID = "slo", Name = "Slovakia", GameID = "yo", SportID = "skat", LogoImage = "slovakia.png" },
                new { CountryID = "swe", Name = "Sweden", GameID = "wo", SportID = "curl", LogoImage = "sweden.png" },
                new { CountryID = "tha", Name = "Thailand", GameID = "p", SportID = "arch", LogoImage = "thailand.png" },
                new { CountryID = "ukr", Name = "Ukraine", GameID = "p", SportID = "arch", LogoImage = "ukraine.png" },
                new { CountryID= "uni", Name = "United Kingdom", GameID = "wo", SportID = "curl", LogoImage = "unitedkingdom.png"},
                new { CountryID = "uru", Name = "Uruguay", GameID = "p", SportID = "arch", LogoImage = "uruguay.png" },
                new { CountryID = "usa", Name = "U.S.A", GameID = "so", SportID = "cycl", LogoImage = "usa.png" },
                new { CountryID = "zim", Name = "Zimbabwe", GameID = "p", SportID = "cano", LogoImage = "zimbabwe.png" }

            );
        }
    }
}
