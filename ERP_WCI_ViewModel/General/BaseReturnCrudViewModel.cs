using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ERP_WCI_ViewModel.General
{
    public class BaseReturnCrudViewModel
    {
        public dynamic ReturnValue { get; set; }
        public string ReturnMessage { get; set; }
        public HttpStatusCode Status { get; set; }
    }
}
