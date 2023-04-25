using ERP_WCI_Model.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_WCI_Model.Common
{
    public class PhoneNumberPersonalInformation : PhoneNumber
    {
        public int PhoneNumberPersonalInformationId { get; set; }
        public int PersonalInformationId { get; set; }
        public PersonalInformation PersonalInformation { get; set; }
    }
}
