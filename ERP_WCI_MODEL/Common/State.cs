using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERP_WCI_Model.Common
{
    public class State : BaseModel
    {
        public int StateId { get; set; }
        public string Name { get; set; }
        public string FederativeUnit { get; set; }
        public string ExternalCode { get; set; }        
    }
}
