using ERP_WCI_Model.Companies;
using ERP_WCI_Model.General;
using ERP_WCI_ViewModel.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_WCI_ViewModel.Companies
{
    public class CompanyConfigNfeViewModel : BaseViewModel
    {
        public int CompanyConfigNFeId { get; set; }
        public Guid CompanyId { get; set; }
        public CompanyViewModel Company { get; set; }
        public int CurrentNumberNfe { get; set; }
        public string VersionNfe { get; set; }
        public EEnvironment EnvironmentNFE { get; set; }

        public static implicit operator CompanyConfigNfeViewModel(CompanyConfigNfe model)
        {
            return new CompanyConfigNfeViewModel()
            {
                CompanyConfigNFeId = model.CompanyConfigNFeId,
                CompanyId = model.CompanyId,
                Company = model.Company,
                CurrentNumberNfe = model.CurrentNumberNfe,
                VersionNfe = model.VersionNfe,
                EnvironmentNFE = model.EnvironmentNFE
            };
        }
    }
}
