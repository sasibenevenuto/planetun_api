using ERP_WCI_Model.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_WCI_Context.Products
{
    public class ProductNCMConfig
    {
        public static ModelBuilder ProductNCMConfigModelBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductNCM>()
                .HasKey(c => c.ProductNCMId)
                .HasName("PrimaryKey_ProductNCMId");

            modelBuilder.Entity<ProductNCM>()
                    .Property(c => c.NCM)
                    .HasMaxLength(20)
                    .IsRequired();

            modelBuilder.Entity<ProductNCM>()
                    .Property(c => c.Simple)
                    .HasColumnType("decimal(5,2)")
                    .IsRequired();

            modelBuilder.Entity<ProductNCM>()
                    .Property(c => c.SimpleTaxSubstitution)
                    .HasColumnType("decimal(5,2)");

            modelBuilder.Entity<ProductNCM>()
                    .Property(c => c.BCICMS)
                    .HasColumnType("decimal(5,2)");

            modelBuilder.Entity<ProductNCM>()
                    .Property(c => c.AliquotICMSOrigin)
                    .HasColumnType("decimal(5,2)");

            modelBuilder.Entity<ProductNCM>()
                    .Property(c => c.AliquotICMSDestination)
                    .HasColumnType("decimal(5,2)");

            modelBuilder.Entity<ProductNCM>()
                    .Property(c => c.MarginValueAggregate)
                    .HasColumnType("decimal(5,2)");

            modelBuilder.Entity<ProductNCM>()
                  .Property(c => c.BCICMS_ST)
                  .HasColumnType("decimal(5,2)");

            modelBuilder.Entity<ProductNCM>()
                  .Property(c => c.ValueIcms_ST)
                  .HasColumnType("decimal(5,2)");

            modelBuilder.Entity<ProductNCM>()                
               .HasOne(c => c.Company)
               .WithMany()
               .HasForeignKey(c => c.CompanyId);

            return modelBuilder;
        }
    }
}
