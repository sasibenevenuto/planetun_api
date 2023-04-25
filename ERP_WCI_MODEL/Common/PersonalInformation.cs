using ERP_WCI_Model.Companies;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_WCI_Model.Common
{
    public class PersonalInformation : BaseModel
    {
        public int PersonalInformationId { get; set; }
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
        public string Name { get; set; }
        public string IndividualResistration { get; set; }                
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public string AddressNumber { get; set; }
        public string AddressComplement { get; set; }

        public List<PhoneNumberPersonalInformation> PhoneNumbers { get; set; }
    }
}
