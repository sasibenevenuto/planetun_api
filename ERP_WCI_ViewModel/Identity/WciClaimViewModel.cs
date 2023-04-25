using ERP_WCI_Model.Common;
using ERP_WCI_Model.Identity;
using ERP_WCI_ViewModel.Common;
using ERP_WCI_ViewModel.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_WCI_ViewModel.Identity
{
    public class WciClaimViewModel : BaseViewModel
    {
        public int WciClaimId { get; set; }
        public string NickName { get; set; }
        public string NameType { get; set; }
        public string Value { get; set; }

        public static implicit operator WciClaimViewModel(WciClaim model)
        {
            return new WciClaimViewModel
            {
                WciClaimId = model.WciClaimId,
                NickName = model.NickName,
                NameType = model.NameType,
                Value = model.Value
            };
        }
    }
}
