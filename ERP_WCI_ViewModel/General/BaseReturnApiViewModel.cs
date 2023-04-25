using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_WCI_ViewModel.General
{   
    public class BaseReturnApiViewModel<Entity> where Entity : BaseViewModel
    {
        public int Count { get; set; }
        public int CurrentPag { get; set; }
        public List<Entity> ListData { get; set; }
        public Entity Data { get; set; }

    }
}
