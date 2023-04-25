using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_WCI_ViewModel.Commands.Common.City
{
    public class CommandAddCity
    {
        public string Name { get; set; }
        public string ExternalCode { get; set; }
        public int StateId { get; set; }
    }
}
