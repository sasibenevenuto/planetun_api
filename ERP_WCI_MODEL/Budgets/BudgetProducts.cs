using ERP_WCI_Model.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_WCI_Model.Budgets
{
    public class BudgetProducts : BaseModel
    {
        public int BudgetProductsId { get; set; }
        public int ProductId { get; set; }
        public Product Product  { get; set; }
        public decimal ProductPriceBudget { get; set; }
        public int BudgetId { get; set; }
        public Budget Budget { get; set; }

    }
}
