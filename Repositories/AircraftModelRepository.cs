using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AircraftReport.Models;
using AircraftReport.Repositories;

namespace AircraftReport.Repositories
{
    public class AircraftModelRepository
    {
        public List<AircraftModel> aircraftModelList { get; private set; }
        public AircraftModelRepository()
        {
            aircraftModelList = new List<AircraftModel>();
            aircraftModelList.Add(new AircraftModel("2022Sep28_DY749", "B738", "47A05E"));
            aircraftModelList.Add(new AircraftModel("2022Sep28_SK1462", "A321", "45AC42"));
            aircraftModelList.Add(new AircraftModel("2022Oct03_LH2452", "A320", "3C66E1"));
            aircraftModelList.Add(new AircraftModel("2022Oct03_D84103", "B738", "4ACA53"));
            aircraftModelList.Add(new AircraftModel("2022Oct03_JU450", "A319", "4C01EC"));
            aircraftModelList.Add(new AircraftModel("2022Oct03_ET500", "B77L", "040075"));
            aircraftModelList.Add(new AircraftModel("2022Oct03_KE93", "B77W", "71C007"));
            aircraftModelList.Add(new AircraftModel("2022Oct03_AA5679", "CRJ9", "A7E630"));
            aircraftModelList.Add(new AircraftModel("2022Oct03_R6984", "AT43", "458D32"));
        }
        public List<AircraftModel> Retrieve()
        {
            return aircraftModelList;
        }
        public (string, string) Retrieve(string id)
        {
            string modelNo = aircraftModelList.Where(a => a.AircraftID == id).First().ModelNo;
            string description = aircraftModelList.Where(a => a.AircraftID == id).First().ModelDescription;
            return (modelNo, description);
        }
    }
}
