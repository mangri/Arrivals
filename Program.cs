using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using AircraftReport.Repositories;
using AircraftReport.Models;
using HtmlAgilityPack;
using AircraftReport.Services;
using System.Net.Mail;
using System.Net;
using System.IO;


namespace AircraftReport
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool confirmation = Initializer();
            if(!confirmation)
            {
                Console.WriteLine("\n\n Email was not sent. " +
                    "Please find the reason above.");
            }
            Console.ReadLine();
        }
        private static bool Initializer()
        {
            AircraftRepository aircraftRepo =
                new AircraftRepository();
            CountryRepository countryRepo =
                new CountryRepository();
            AircraftModelRepository aircraftModelRepo =
                new AircraftModelRepository();
            CompanyRepository companyRepo =
                new CompanyRepository();

            ReportGenerator generatingReport = new ReportGenerator(
                aircraftRepo, aircraftModelRepo,
                companyRepo, countryRepo);

            (List<ReportItem> ataskaitaEurope, List <ReportItem> ataskaitaNOTEurope) =
                generatingReport.GenerateReportAircraftInEurope();
            HTMLGenerator generatingHTML = new HTMLGenerator();
            (string textEurope, string textNOTEurope) = 
                generatingHTML.GenerateHTMLWithColor(ataskaitaEurope, ataskaitaNOTEurope);

            EmailSender smtpClient = new EmailSender();
            bool sent = smtpClient.SendEmail(textEurope, textNOTEurope);
            return sent;
        }
    }
}
