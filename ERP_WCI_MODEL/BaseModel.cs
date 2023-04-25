using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_WCI_Model
{
    public class BaseModel
    {   
        public bool Active { get; set; }        
        public DateTime CreateDate { get; set; }        
        public DateTime ModifieldDate { get; set; }
        public int UserID { get; set; }
        public int UserIDLastUpdate { get; set; }
    }
}
