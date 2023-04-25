using ERP_WCI_Model.Common;
using ERP_WCI_ViewModel.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_WCI_ViewModel.Common
{
    public class CityViewModel : BaseViewModel
    {
        public int CityId { get; set; }
        public string Name { get; set; }
        public string ExternalCode { get; set; }
        public int StateId { get; set; }
        public StateViewModel State { get; set; }

        public static implicit operator CityViewModel(City model)
        {
            return new CityViewModel()
            {
                CityId = model.CityId,
                Name = model.Name,
                ExternalCode = model.ExternalCode,
                State = model.State
            };
        }
    }
}
