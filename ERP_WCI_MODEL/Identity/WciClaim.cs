using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_WCI_Model.Identity
{
    public class WciClaim : BaseModel
    {
        public int WciClaimId { get; set; }
        public string NickName { get; set; }
        public string NameType { get; set; }
        public string Value { get; set; }

    }
}
