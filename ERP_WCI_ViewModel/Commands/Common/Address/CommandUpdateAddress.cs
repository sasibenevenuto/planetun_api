using ERP_WCI_ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_WCI_ViewModel.Commands.Common.Address
{
    public class CommandUpdateAddress
    {
        public int AddressId { get; set; }
        public string PostalCode { get; set; }
        public string AddressStreet { get; set; }
        public string Neighborhood { get; set; }
        public int CityId { get; set; }        
        public int StateId { get; set; }
    }
}
