using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftReport.Models
{
    public class Country
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsInEu { get; set; }
        public Country(string code, string name, bool isInEu)
        {
            Code = code;
            Name = name;
            IsInEu = isInEu;
        }
    }
}
