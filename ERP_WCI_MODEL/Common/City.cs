using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_WCI_Model.Common
{
    public class City : BaseModel
    {   
        public int CityId { get; set; }
        public string Name { get; set; }
        public string ExternalCode { get; set; }
        public int StateId { get; set; }
        public State State { get; set; }
    }
}
