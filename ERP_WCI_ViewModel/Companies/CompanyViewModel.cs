using ERP_WCI_Model.Companies;
using ERP_WCI_ViewModel.Common;
using ERP_WCI_ViewModel.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_WCI_ViewModel.Companies
{
    public class CompanyViewModel : BaseViewModel
    {
        public Guid CompanyId { get; set; }
        public Guid AccountId { get; set; }
        public AccountViewModel Account { get; set; }
        public CompanyConfigNfeViewModel CompanyConfigNfe { get; set; }
        public string TradingName { get; set; }
        public string FantasyName { get; set; }
        public string CNPJ { get; set; }
        public string StateRegistration { get; set; }
        public string CNAE { get; set; }
        public string MunicipalityRegistration { get; set; }
        public string StateRegistrationReplaceTributary { get; set; }
        public string LogoBase64 { get; set; }
        public int AddressId { get; set; }
        public AddressViewModel Address { get; set; }
        public string AddressNumber { get; set; }
        public string AddressComplement { get; set; }
        public List<PhoneNumberCompanyViewModel> PhoneNumbers { get; set; }

        public static implicit operator CompanyViewModel(Company model)
        {
            var companiesViewModel =  new CompanyViewModel()
            {
                CompanyId = model.CompanyId,
                AccountId = model.AccountId,
                Account = model.Account,
                CompanyConfigNfe = model.CompanyConfigNfe,
                TradingName = model.TradingName,
                FantasyName = model.FantasyName,
                CNPJ = model.CNPJ,
                StateRegistration = model.StateRegistration,
                CNAE = model.CNAE,
                MunicipalityRegistration = model.MunicipalityRegistration,
                StateRegistrationReplaceTributary = model.StateRegistrationReplaceTributary,
                LogoBase64 = model.LogoBase64,
                AddressId = model.AddressId,
                AddressNumber = model.AddressNumber,
                AddressComplement = model.AddressComplement
            };

            model.PhoneNumbers.ForEach(f => companiesViewModel.PhoneNumbers.Add(f));

            return companiesViewModel;
        }
    }
}
