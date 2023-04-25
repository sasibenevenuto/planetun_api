using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_WCI_Model.Identity
{
    public class User : IdentityUser
    {
        public override string Id { get; set; }
        public override string UserName { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public string LoginToken { get; set; }
        public override string PasswordHash { get; set; }        
        public override string Email { get; set; }
        public override bool EmailConfirmed { get; set; }        
        public override string SecurityStamp { get; set; }
        public override bool LockoutEnabled { get; set; }
        public override int AccessFailedCount { get; set; }
        public bool Active { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifieldDate { get; set; }
    }
}
