using ERP_WCI_Model.Budgets;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_WCI_Context.Budgets
{
    public static class BudgetConfig
    {
        public static ModelBuilder BudgetConfigModelBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Budget>()
                .HasKey(b => b.BudgetId)
                .HasName("PrimaryKey_BudgetId");

            modelBuilder.Entity<Budget>()
                .HasOne(b => b.Customer)
                .WithMany()
                .HasForeignKey(b => b.CustomerId);

            modelBuilder.Entity<Budget>()
                .Property(b => b.DateBudget)
                .HasColumnType("datetime");

            modelBuilder.Entity<Budget>()
                .Property(b => b.ValidateBudget)
                .HasColumnType("datetime");

            modelBuilder.Entity<Budget>()
                .HasMany(b => b.BudgetProducts)
                .WithOne(b => b.Budget);

            return modelBuilder;
        }

    }
}
