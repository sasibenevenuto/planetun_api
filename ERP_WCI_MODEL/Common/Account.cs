using ERP_WCI_Model.Companies;
using ERP_WCI_Model.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP_WCI_Model.Common
{
    public class Account : BaseModel
    {
        public Guid AccountId { get; set; }        
        public string EmailAccount { get; set; }
        public ETypeAccount TypeAccount { get; set; }
        public Guid? CompanyActived { get; set; }
    }
}
