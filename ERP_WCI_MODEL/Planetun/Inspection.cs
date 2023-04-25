using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_WCI_Model.Planetun
{
    public class Inspection : BaseModel
    {
        public int InspectionId { get; set; }
        public int CompanyId { get; set; }
        public string BrokerCode { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string InspectionNumber { get; set; }
    }
}
