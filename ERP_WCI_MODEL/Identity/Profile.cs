using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_WCI_Model.Identity
{
    public class Profile : BaseModel
    {
        public int ProfileId { get; set; }
        public string Description { get; set; }
    }
}
