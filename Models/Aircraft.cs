using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftReport.Models
{
    public class Aircraft
    {
        public string ID { get; set; }
        public string TailNo { get; set; }
        public string CompanyName { get; set; }
        public Aircraft(string id, string tailNo, string companyName)
        {
            ID = id;
            TailNo = tailNo;
            CompanyName = companyName;
        }
    }

}
