using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_WCI_ViewModel.Commands.Planetun
{
    public class CommandAddInspection
    {
        public int CompanyId { get; set; }
        public string BrokerCode { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string InspectionNumber { get; set; }
    }
}
