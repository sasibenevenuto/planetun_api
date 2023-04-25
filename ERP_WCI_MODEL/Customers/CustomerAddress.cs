using ERP_WCI_Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_WCI_Model.Customers
{
    public class CustomerAddress : BaseModel
    {
        public int CustomerAddressId { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }


    }
}
