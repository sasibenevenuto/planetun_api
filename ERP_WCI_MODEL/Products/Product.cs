using ERP_WCI_Model.Companies;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_WCI_Model.Products
{
    public class Product : BaseModel
    {
        public int ProductId { get; set; }
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string EuropeanArticleNumber { get; set; }
        public string EuropeanArticleNumberUT { get; set; }
        public string ExTipi { get; set; }
        public string CEST { get; set; }       

        public int ProductNCMId { get; set; }
        public ProductNCM ProductNCM { get; set; }
        public int ProductUnitCommercialId { get; set; }
        public ProductUnit ProductUnitCommercial { get; set; }
        public decimal ValueCommercialUnit { get; set; }
        public int ProductUnitTributaryId { get; set; }
        public ProductUnit ProductUnitTributary { get; set; }
        public decimal TributaryAmount { get; set; }
        public decimal ValueTributaryUnit { get; set; }

    }
}
