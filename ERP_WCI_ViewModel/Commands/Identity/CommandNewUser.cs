using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_WCI_ViewModel.Commands.Identity
{
    public class CommandNewUser
    {
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string LoginToken { get; set; }
    }
}
