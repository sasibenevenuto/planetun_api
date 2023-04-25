using ERP_WCI_Context;
using ERP_WCI_Model.Companies;
using ERP_WCI_Repository.Companies.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_WCI_Repository.Companies
{
    public class RCompanyConfigNfe : Repository<CompanyConfigNfe>, IRCompanyConfigNfe
    {
        public RCompanyConfigNfe(Context context) : base(context)
        {

        }
    }
}
