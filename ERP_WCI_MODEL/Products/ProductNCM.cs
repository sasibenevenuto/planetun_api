using ERP_WCI_Model.Companies;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_WCI_Model.Products
{
    public class ProductNCM : BaseModel
    {
        public int ProductNCMId { get; set; }
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
        public string NCM { get; set; }
        public decimal Simple { get; set; }
        public decimal? SimpleTaxSubstitution { get; set; }
        public decimal? BCICMS { get; set; }
        public decimal? AliquotICMSOrigin { get; set; }
        public decimal? AliquotICMSDestination { get; set; }
        public decimal? MarginValueAggregate { get; set; }
        public decimal? BCICMS_ST { get; set; }
        public decimal? ValueIcms_ST { get; set; }

        public List<Product> Products { get; set; }
    }
}
