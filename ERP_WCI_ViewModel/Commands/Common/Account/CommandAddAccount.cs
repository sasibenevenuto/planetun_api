using ERP_WCI_Model.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ERP_WCI_ViewModel.Commands.Common.Account
{
    public class CommandAddAccount
    {       
        public string EmailAccount { get; set; }
        public ETypeAccount TypeAccount { get; set; }
        public Guid? CompanyActived { get; set; }
    }
}
