using ERP_WCI_Model.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_WCI_ViewModel.Commands.Common.PhoneNumber
{
    public class CommandAddPhoneNumber
    {        
        public TypePhone TypePhone { get; set; }
        public string Number { get; set; }
        public bool MainPhone { get; set; }
    }
}
