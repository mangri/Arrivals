using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AircraftReport.Models;
using AircraftReport.Repositories;

namespace AircraftReport.Repositories
{
    public class AircraftRepository
    {
        public List<Aircraft> aircraftList { get; private set; }
        public AircraftRepository()
        {
            aircraftList = new List<Aircraft>();
            aircraftList.Add(new Aircraft("2022Sep28_DY749", "LN-ENV", "Norwegian"));
            aircraftList.Add(new Aircraft("2022Sep28_SK1462", "OY-KBB", "SAS"));
            aircraftList.Add(new Aircraft("2022Oct03_LH2452", "D-AIWA", "Lufthansa"));
            aircraftList.Add(new Aircraft("2022Oct03_D84103", "SE-RRS", "Norwegian (Helge Ingstad Livery)"));
            aircraftList.Add(new Aircraft("2022Oct03_JU450", "YU-APM", "AirSERBIA"));
            aircraftList.Add(new Aircraft("2022Oct03_ET500", "ET-AQL", "Ethiopian Airlines"));
            aircraftList.Add(new Aircraft("2022Oct03_KE93", "HL8007", "Korean Air"));
            aircraftList.Add(new Aircraft("2022Oct03_AA5679", "N608NN", "American Eagle"));
            aircraftList.Add(new Aircraft("2022Oct03_R6984", "OY-CIR", "DAT"));
        }
        public List<Aircraft> Retrieve()
        {
            return aircraftList;
        }
        public (string, string) Retrieve(string id)
        {
            string tail = aircraftList.Where(a => a.ID == id).First().TailNo;
            string compName = aircraftList.Where(a => a.ID == id).First().CompanyName;
            return (tail, compName);
        }
    }



}
