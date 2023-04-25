using ERP_WCI_Model.General;
using ERP_WCI_ViewModel.Commands.Common.Address;
using ERP_WCI_ViewModel.Commands.Common.PhoneNumber;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_WCI_ViewModel.Commands.Common.PersonalInformation
{
    public class CommandUpdatePersonalInformation
    {
        public int PersonalInformationId { get; set; }
        public Guid CompanyId { get; set; }
        public string Name { get; set; }
        public string IndividualResistration { get; set; }
        public int AddressId { get; set; }
        public CommandAddAddress Address { get; set; }
        public string AddressNumber { get; set; }
        public string AddressComplement { get; set; }
        public List<CommandUpdatePhoneNumber> PhoneNumbers { get; set; }
    }
}
