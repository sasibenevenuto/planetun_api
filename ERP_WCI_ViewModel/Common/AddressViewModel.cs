using ERP_WCI_Model.Common;
using ERP_WCI_ViewModel.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_WCI_ViewModel.Common
{
    public class AddressViewModel : BaseViewModel
    {
        public int AddressId { get; set; }
        public string PostalCode { get; set; }
        public string AddressStreet { get; set; }
        public string Neighborhood { get; set; }
        public int CityId { get; set; }
        public int StateId { get; set; }

        public static implicit operator AddressViewModel(Address model)
        {
            return new AddressViewModel()
            {
                AddressId = model.AddressId,
                PostalCode = model.PostalCode,
                AddressStreet = model.AddressStreet,
                Neighborhood = model.Neighborhood,
                CityId = model.CityId,
                StateId = model.StateId
            };
        }
    }
}
