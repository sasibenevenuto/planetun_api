using ERP_WCI_Model.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_WCI_ViewModel.Commands.Common.Account
{
    public class CommandUpdateAccount
    {
        public Guid AccountId { get; set; }
        public string EmailAccount { get; set; }
        public ETypeAccount TypeAccount { get; set; }
        public Guid? CompanyActived { get; set; }
    }
}
