using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_WCI_Model.Products
{
    public class ProductUnit : BaseModel
    {
        public int ProductUnitId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
