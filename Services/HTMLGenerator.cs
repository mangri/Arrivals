using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AircraftReport.Repositories;
using AircraftReport.Models;
using System.Drawing;
using System.Diagnostics;
using System.Numerics;

namespace AircraftReport.Services
{
    public class HTMLGenerator
    {
        public (string, string) GenerateHTMLWithColor(List<ReportItem> ataskaitaEurope, 
            List<ReportItem> ataskaitaNOTEurope)
        {
            string[] EuCountries = {
                "Austria", "Belgium", "Bulgaria", "Croatia", "Republic of Cyprus",
                "Czech Republic","Denmark", "Estonia", "Finland", "France",
                "Germany", "Greece", "Hungary", "Ireland", "Italy",
                "Latvia", "Lithuania", "Luxembourg","Malta",
                "Netherlands", "Poland", "Portugal",
                "Romania", "Slovakia","Slovenia",
                "Spain", "Sweden"
            };
            List<string> EuCountriesList = new List<string>(EuCountries);

            string[] NonEuCountries = {
                "United Kingdom", "Iceland", "Norway", "Russia", "Liechtenstein",
                "Switzerland", "Andorra", "Monaco", "San Marino", "Vatican City",
                "Bosnia and Herzegovina", "Serbia", "Montenegro", "Kosovo",
                "Albania", "North Macedonia", "Turkey", "Belarus",
                "Ukraine", "Moldova"
            };
            List<string> NonEuCountriesList = new List<string>(NonEuCountries);

            string[] HTMLcodeEurope = new string[ataskaitaEurope.Count + 3];
            HTMLcodeEurope[0] = "<html><body><table border = \"1\">";
            HTMLcodeEurope[1] = "<tr>" +
            "<th>AIRCRAFT_TAIL_NUMBER</th>" +
            "<th>MODEL_NUMBER</th>" +
                "<th>MODEL_DESCRIPTION</th>" +
                "<th>OWNER_COMPANY_NAME</th>" +
                "<th>COMPANY_COUNTRY_CODE</th>" +
                "<th>COMPANY_COUNTRY_NAME</th>" +
                "</tr>";
            string bgcolor;
            for (int i = 0; i < ataskaitaEurope.Count; i++)
            {
                if (EuCountriesList.Contains(ataskaitaEurope[i].COMPANY_COUNTRY_NAME))
                {
                    bgcolor = "#ADD8E6";
                }
                else if (NonEuCountriesList.Contains(ataskaitaEurope[i].COMPANY_COUNTRY_NAME))
                {
                    bgcolor = "#FFCCCB";
                }
                else
                {
                    bgcolor = "FFFFFF";
                }
                HTMLcodeEurope[i + 2] = $"<tr bgcolor = \"{bgcolor}\"> " +
                    $"<td>{ataskaitaEurope[i].AIRCRAFT_TAIL_NUMBER}</td>" +
                    $"<td>{ataskaitaEurope[i].MODEL_NUMBER}</td>" +
                    $"<td>{ataskaitaEurope[i].MODEL_DESCRIPTION}</td>" +
                    $"<td>{ataskaitaEurope[i].OWNER_COMPANY_NAME}</td>" +
                    $"<td>{ataskaitaEurope[i].COMPANY_COUNTRY_CODE}</td>" +
                    $"<td>{ataskaitaEurope[i].COMPANY_COUNTRY_NAME}</td>" +
                    $"</tr>";
            }
            HTMLcodeEurope[ataskaitaEurope.Count + 2] = "</table></body></html>";
            //Second table start*****************
            string[] HTMLcodeNOTEurope = new string[ataskaitaNOTEurope.Count + 3];
            HTMLcodeNOTEurope[0] = "<html><body><table border = \"1\">";
            HTMLcodeNOTEurope[1] = "<tr>" +
            "<th>AIRCRAFT_TAIL_NUMBER</th>" +
            "<th>MODEL_NUMBER</th>" +
                "<th>MODEL_DESCRIPTION</th>" +
                "<th>OWNER_COMPANY_NAME</th>" +
                "<th>COMPANY_COUNTRY_CODE</th>" +
                "<th>COMPANY_COUNTRY_NAME</th>" +
                "</tr>";
            
            for (int i = 0; i < ataskaitaNOTEurope.Count; i++)
            {
                if (EuCountriesList.Contains(ataskaitaNOTEurope[i].COMPANY_COUNTRY_NAME))
                {
                    bgcolor = "#ADD8E6";
                }
                else if (NonEuCountriesList.Contains(ataskaitaNOTEurope[i].COMPANY_COUNTRY_NAME))
                {
                    bgcolor = "#FFCCCB";
                }
                else
                {
                    bgcolor = "FFFFFF";
                }
                HTMLcodeNOTEurope[i + 2] = $"<tr bgcolor = \"{bgcolor}\"> " +
                    $"<td>{ataskaitaNOTEurope[i].AIRCRAFT_TAIL_NUMBER}</td>" +
                    $"<td>{ataskaitaNOTEurope[i].MODEL_NUMBER}</td>" +
                    $"<td>{ataskaitaNOTEurope[i].MODEL_DESCRIPTION}</td>" +
                    $"<td>{ataskaitaNOTEurope[i].OWNER_COMPANY_NAME}</td>" +
                    $"<td>{ataskaitaNOTEurope[i].COMPANY_COUNTRY_CODE}</td>" +
                    $"<td>{ataskaitaNOTEurope[i].COMPANY_COUNTRY_NAME}</td>" +
                    $"</tr>";
            }
            HTMLcodeNOTEurope[ataskaitaNOTEurope.Count + 2] = "</table></body></html>";
            //Second table end*****************

            return (string.Join("\n", HTMLcodeEurope), string.Join("\n", HTMLcodeNOTEurope));
        }

    }
}
