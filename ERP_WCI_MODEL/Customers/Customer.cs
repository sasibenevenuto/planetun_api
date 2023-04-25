using ERP_WCI_Model.Common;
using ERP_WCI_Model.Companies;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_WCI_Model.Customers
{
    public class Customer : BaseModel
    {
        public int CustomerId { get; set; }
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
        public string TradingName { get; set; }
        public string FantasyName { get; set; }
        public string CPFCNPJ { get; set; }
        public string StateRegistration { get; set; }
        public string MunicipalityRegistration { get; set; }
        public string Suframa { get; set; }
        public string CellPhone { get; set; }
        public string PhoneNumbers { get; set; }
        
        public string AddressNumber { get; set; }
        public string AddressComplement { get; set; }
        public string Observation { get; set; }
    }
}
