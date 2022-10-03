using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AircraftReport.Models;
using AircraftReport.Repositories;

namespace AircraftReport.Repositories
{
    public class CompanyRepository
    {
        public List<Company> companies { get; private set; }

        public CompanyRepository()
        {
            companies = new List<Company>();
            companies.Add(new Company("Norwegian", "Norway"));
            companies.Add(new Company("SAS", "Sweden"));
            companies.Add(new Company("Lufthansa", "Germany"));
            companies.Add(new Company("Norwegian (Helge Ingstad Livery)", "Sweden"));
            companies.Add(new Company("AirSERBIA", "Serbia"));
            companies.Add(new Company("Ethiopian Airlines", "Ethiopia"));
            companies.Add(new Company("Korean Air", "South Korea"));
            companies.Add(new Company("DAT", "Denmark"));
            companies.Add(new Company("American Eagle", "United States"));

        }

        public List<Company> Retrieve()
        {
            return companies;
        }

        public Company Retrieve(string companyName)
        {
            Company company = null;
            company = companies.Where(c => c.Name == companyName).First();
            return company;
        }

    }

}
