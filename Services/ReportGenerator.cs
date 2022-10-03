using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AircraftReport.Models;
using AircraftReport.Repositories;

namespace AircraftReport.Services
{
    public class ReportGenerator
    {
        AircraftRepository aircraftRepository;
        AircraftModelRepository aircraftModelRepository;
        CompanyRepository companyRepository;
        CountryRepository countryRepository;
        public ReportGenerator
            (
            AircraftRepository airRepo,
            AircraftModelRepository airModelRepo,
            CompanyRepository companyRepo,
            CountryRepository countryRepo
            )
        {
            aircraftRepository = airRepo;
            aircraftModelRepository = airModelRepo;
            companyRepository = companyRepo;
            countryRepository = countryRepo;
        }

        public (List<ReportItem>, List<ReportItem>) GenerateReportAircraftInEurope()
        {
            List<Aircraft> allAircrafts = aircraftRepository.Retrieve();
            List<string> aircraftsInEu = new List<string>();
            //Second table start ***************
            List<string> aircraftsNOTInEu = new List<string>();
            //Second table end *****************
            foreach (Aircraft aircraft in allAircrafts)
            {
                if (countryRepository.Retrieve(companyRepository.Retrieve(
                    aircraft.CompanyName).Country).IsInEu)
                {
                    aircraftsInEu.Add(aircraft.ID);
                }
                //Second table start ***********
                else
                {
                    aircraftsNOTInEu.Add(aircraft.ID);
                }
                //Second table end *************
            }

            List<ReportItem> reportInEU = new List<ReportItem>();

            foreach (string bird in aircraftsInEu)
            {
                ReportItem item = new ReportItem();
                (item.AIRCRAFT_TAIL_NUMBER, item.OWNER_COMPANY_NAME) =
                    aircraftRepository.Retrieve(bird);
                (item.MODEL_NUMBER, item.MODEL_DESCRIPTION) =
                    aircraftModelRepository.Retrieve(bird);
                Country itemCountry = countryRepository.Retrieve(
                    companyRepository.Retrieve(allAircrafts.Where(
                        b => b.ID == bird).First().CompanyName).Country);
                item.COMPANY_COUNTRY_CODE = itemCountry.Code;
                item.COMPANY_COUNTRY_NAME = itemCountry.Name;

                reportInEU.Add(item);
            }
            //Second table start ***************
            List<ReportItem> reportNOTInEU = new List<ReportItem>();

            foreach (string bird in aircraftsNOTInEu)
            {
                ReportItem item = new ReportItem();
                (item.AIRCRAFT_TAIL_NUMBER, item.OWNER_COMPANY_NAME) =
                    aircraftRepository.Retrieve(bird);
                (item.MODEL_NUMBER, item.MODEL_DESCRIPTION) =
                    aircraftModelRepository.Retrieve(bird);
                Country itemCountry = countryRepository.Retrieve(
                    companyRepository.Retrieve(allAircrafts.Where(
                        b => b.ID == bird).First().CompanyName).Country);
                item.COMPANY_COUNTRY_CODE = itemCountry.Code;
                item.COMPANY_COUNTRY_NAME = itemCountry.Name;

                reportNOTInEU.Add(item);
            }
            //Second table end ****************
            if (reportInEU.Count == 0)
            {
                ReportItem item = new ReportItem(
                    " ", " ", " ", " ", " ", " ");
                reportInEU.Add(item);
                //return reportInEU;
            }
            //Second table start **************
            if (reportNOTInEU.Count == 0)
            {
                ReportItem item = new ReportItem(
                    " ", " ", " ", " ", " ", " ");
                reportNOTInEU.Add(item);
                //return reportInEU;
            }
            //Second table end ****************
            return (reportInEU, reportNOTInEU);
        }
    }
}
