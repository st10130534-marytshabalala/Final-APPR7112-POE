using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mary_tshabalala_MunicipalServicesApp
{
    public class ServiceRequest
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Location { get; set; }
        public string Category { get; set; }
        public DateTime SubmittedDate { get; set; }
    }
}