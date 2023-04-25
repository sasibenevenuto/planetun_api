using ERP_WCI_Model.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_WCI_Model.Companies
{
    public class PhoneNumberCompany : PhoneNumber
    {
        public int PhoneNumberCompanyId { get; set; }
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }        
    }
}
