using ERP_WCI_Model.Common;
using ERP_WCI_ViewModel.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP_WCI_ViewModel.Common
{
    public class StateViewModel : BaseViewModel
    {
        public int StateId { get; set; }
        public string Name { get; set; }
        public string FederativeUnit { get; set; }
        public string ExternalCode { get; set; }        

        public static implicit operator StateViewModel(State model)
        {
            return new StateViewModel
            {
                StateId = model.StateId,
                Name = model.Name,
                FederativeUnit = model.FederativeUnit,
                ExternalCode = model.ExternalCode
            };
        }
    }
}
