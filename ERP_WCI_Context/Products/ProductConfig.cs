using ERP_WCI_Model.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_WCI_Context.Products
{
    public static class ProductConfig
    {
        public static ModelBuilder ProductConfigModelBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasKey(c => c.ProductId)
                .HasName("PrimaryKey_ProductId");

            modelBuilder.Entity<Product>()
                .Property(c => c.ProductCode)
                .HasMaxLength(20)
                .IsRequired();

            modelBuilder.Entity<Product>()
                .Property(c => c.ProductName)
                .HasMaxLength(20)
                .IsRequired();

            modelBuilder.Entity<Product>()
               .Property(c => c.EuropeanArticleNumber)
               .HasMaxLength(20);

            modelBuilder.Entity<Product>()
               .Property(c => c.EuropeanArticleNumberUT)
               .HasMaxLength(20);

            modelBuilder.Entity<Product>()
               .Property(c => c.ValueCommercialUnit);

            modelBuilder.Entity<Product>()
               .HasOne(c => c.ProductUnitCommercial)
               .WithMany()
               .HasForeignKey(c => c.ProductUnitCommercialId);

            modelBuilder.Entity<Product>()
               .HasOne(c => c.Company)
               .WithMany()
               .HasForeignKey(c => c.CompanyId);

            modelBuilder.Entity<Product>()
               .HasOne(c => c.ProductNCM)
               .WithMany(pn => pn.Products)
               .HasForeignKey(c => c.ProductNCMId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Product>()
               .HasOne(c => c.ProductUnitCommercial)
               .WithMany()
               .HasForeignKey(c => c.ProductUnitCommercialId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Product>()
               .HasOne(c => c.ProductUnitTributary)
               .WithMany()
               .HasForeignKey(c => c.ProductUnitTributaryId)
               .OnDelete(DeleteBehavior.Restrict);

            return modelBuilder;
        }
    }
}
