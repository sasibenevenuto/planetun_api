using ERP_WCI_Business.Companies.Interfaces;
using ERP_WCI_Context;
using ERP_WCI_Repository.Companies;
using ERP_WCI_Repository.Companies.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_WCI_Business.Companies
{
    public class BCompanyConfigNfe : IBCompanyConfigNfe
    {
        private readonly IRCompanyConfigNfe _rCompanyConfigNfe;
        public BCompanyConfigNfe(IRCompanyConfigNfe rCompanyConfigNfe)
        {
            _rCompanyConfigNfe = rCompanyConfigNfe;
        }
    }
}
