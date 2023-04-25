using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_WCI_Model.General
{
    public class PhoneNumber : BaseModel
    {        
        public TypePhone TypePhone { get; set; }
        public string Number { get; set; }
        public bool MainPhone { get; set; }
    }
}
