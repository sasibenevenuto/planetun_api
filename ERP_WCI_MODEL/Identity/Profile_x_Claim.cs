using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_WCI_Model.Identity
{
    public class Profile_x_Claim : BaseModel
    {
        public int Profile_x_ClaimId { get; set; }
        public int ProfileId { get; set; }
        public Profile Profile { get; set; }
        public int WciClaimId { get; set; }
        public WciClaim  WciClaim { get; set; }
    }
}
