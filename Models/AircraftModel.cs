using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftReport.Models
{
    public class AircraftModel
    {
        public string AircraftID { get; set; }
        public string ModelNo { get; set; }
        public string ModelDescription { get; set; }
        public AircraftModel(string aircraftID, string modelNo, string modelDescription)
        {
            AircraftID = aircraftID;
            ModelNo = modelNo;
            ModelDescription = modelDescription;
        }
    }
}
