using ERP_WCI_Model.Common;
using ERP_WCI_Model.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_WCI_Model.Companies
{
    public class CompanyConfigNfe : BaseModel
    {
        public int CompanyConfigNFeId { get; set; }
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
        public int CurrentNumberNfe { get; set; }
        public string VersionNfe { get; set; }
        public EEnvironment EnvironmentNFE { get; set; }
    }
}
