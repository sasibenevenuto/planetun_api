using ERP_WCI_Model.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_WCI_Context.Products
{
    public class ProductUnitConfig
    {
        public static ModelBuilder ProductUnitConfigModelBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductUnit>()
                .HasKey(c => c.ProductUnitId)
                .HasName("PrimaryKey_ProductUnitId");

            modelBuilder.Entity<ProductUnit>()
                    .Property(c => c.Code)
                    .HasMaxLength(20)
                    .IsRequired();

            modelBuilder.Entity<ProductUnit>()
                    .Property(c => c.Name)
                    .HasMaxLength(30)
                    .IsRequired();

            modelBuilder.Entity<ProductUnit>()
                    .Property(c => c.Description)
                    .HasMaxLength(30)
                    .IsRequired();

            return modelBuilder;
        }
    }
}
