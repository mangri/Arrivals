using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AircraftReport.Models;
using AircraftReport.Repositories;

namespace AircraftReport.Repositories
{
    public class CountryRepository
    {
        public List<Country> countries { get; private set; }

        public CountryRepository()
        {
            countries = new List<Country>();
            countries.Add(new Country("NOR", "Norway", true));
            countries.Add(new Country("DNK", "Denmark", true));
            countries.Add(new Country("DEU", "Germany", true));
            countries.Add(new Country("SWE", "Sweden", true));
            countries.Add(new Country("SRB", "Serbia", true));
            countries.Add(new Country("ETH", "Ethiopia", false));
            countries.Add(new Country("KOR", "South Korea", false));
            countries.Add(new Country("USA", "United States", false));
        }

        public List<Country> Retrieve()
        {
            return countries;
        }

        public Country Retrieve(string countryName)
        {
            Country country = null;
            country = countries.Where(c => c.Name == countryName).First();
            return country;
        }
    }
}
