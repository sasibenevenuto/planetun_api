using ERP_WCI_Model.Customers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_WCI_Model.Budgets
{
    public class Budget : BaseModel
    {
        public int BudgetId { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public DateTime DateBudget { get; set; }
        public DateTime ValidateBudget { get; set; }
        
        public List<BudgetProducts> BudgetProducts { get; set; }
    }
}
