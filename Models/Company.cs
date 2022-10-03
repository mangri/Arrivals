using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftReport.Models
{
    public class Company
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public Company(string name, string country)
        {
            Name = name;
            Country = country;
        }
    }

}
