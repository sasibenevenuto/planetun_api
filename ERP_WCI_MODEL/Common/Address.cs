using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_WCI_Model.Common
{
    public class Address : BaseModel
    {
        public int AddressId { get; set; }
        public string PostalCode { get; set; }
        public string AddressStreet { get; set; }        
        public string Neighborhood { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public int StateId { get; set; }
        public State State { get; set; }
    }
}
