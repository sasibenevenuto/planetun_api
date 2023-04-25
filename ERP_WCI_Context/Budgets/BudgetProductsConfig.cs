using ERP_WCI_Model.Budgets;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_WCI_Context.Budgets
{
    public static class BudgetProductsConfig
    {
        public static ModelBuilder BudgetProductsConfigModelBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BudgetProducts>()
                .HasKey(b => b.BudgetProductsId)
                .HasName("PrimaryKey_BudgetProductsId");

            modelBuilder.Entity<BudgetProducts>()
                .HasOne(b => b.Product)
                .WithMany()
                .HasForeignKey(b => b.ProductId);

            modelBuilder.Entity<BudgetProducts>()
                .Property(b => b.ProductPriceBudget)
                .HasColumnType("decimal(7,2)");

            modelBuilder.Entity<BudgetProducts>()
                .HasOne(b => b.Budget)
                .WithMany(b => b.BudgetProducts)
                .HasForeignKey(b => b.BudgetId)
                .OnDelete(DeleteBehavior.Restrict);


            return modelBuilder;
        }
    }
}
