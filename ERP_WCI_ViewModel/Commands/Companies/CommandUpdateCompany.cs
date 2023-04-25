using ERP_WCI_ViewModel.Commands.Common.Address;
using ERP_WCI_ViewModel.Commands.Common.PhoneNumber;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_WCI_ViewModel.Commands.Companies
{
    public class CommandUpdateCompany
    {
        public Guid CompanyId { get; set; }
        public Guid AccountId { get; set; }
        public string TradingName { get; set; }
        public string FantasyName { get; set; }
        public string CNPJ { get; set; }
        public string StateRegistration { get; set; }
        public string CNAE { get; set; }
        public string MunicipalityRegistration { get; set; }
        public string StateRegistrationReplaceTributary { get; set; }
        public string LogoBase64 { get; set; }
        public int AddressId { get; set; }
        public CommandAddAddress Address { get; set; }
        public string AddressNumber { get; set; }
        public string AddressComplement { get; set; }
        public List<CommandAddPhoneNumber> PhoneNumbers { get; set; }
    }
}
