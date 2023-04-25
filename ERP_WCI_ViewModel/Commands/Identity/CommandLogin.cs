using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_WCI_ViewModel.Commands.Identity
{
    public class CommandLogin
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string TokenUser { get; set; }
    }
}
