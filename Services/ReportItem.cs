using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AircraftReport.Services
{
    public class ReportItem
    {
        public string AIRCRAFT_TAIL_NUMBER { get; set; }
        public string MODEL_NUMBER { get; set; }
        public string MODEL_DESCRIPTION { get; set; }
        public string OWNER_COMPANY_NAME { get; set; }
        public string COMPANY_COUNTRY_CODE { get; set; }
        public string COMPANY_COUNTRY_NAME { get; set; }
        public ReportItem(string tailNo, string modelNo,
            string modelDescription, string companyName,
            string countryCode, string countryName)
        {
            AIRCRAFT_TAIL_NUMBER = tailNo;
            MODEL_NUMBER = modelNo;
            MODEL_DESCRIPTION = modelDescription;
            OWNER_COMPANY_NAME = companyName;
            COMPANY_COUNTRY_CODE = countryCode;
            COMPANY_COUNTRY_NAME = countryName;
        }
        public ReportItem()
        {

        }

    }
}
