using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_WCI_Model.Identity
{
    public class TokenConfigurations
    {
        public string Audience { get; set; } = "IdentityAudience";
        public string Issuer { get; set; } = "IdentityIssuer";
        public int Seconds { get; set; } = 3600;
    }
}
