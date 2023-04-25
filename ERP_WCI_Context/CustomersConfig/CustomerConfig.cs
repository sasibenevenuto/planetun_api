using ERP_WCI_Model.Customers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_WCI_Context.CustomersConfig
{
    public static class CustomerConfig
    {
        public static ModelBuilder CustomerConfigModelBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasKey(c => c.CustomerId)
                .HasName("PrimaryKey_CustomerId");

            modelBuilder.Entity<Customer>()
                .Property(c => c.TradingName)
                .HasMaxLength(300)
                .IsRequired();

            modelBuilder.Entity<Customer>()
                .Property(c => c.FantasyName)
                .HasMaxLength(300);

            modelBuilder.Entity<Customer>()
                .Property(c => c.CPFCNPJ)
                .HasMaxLength(20)
                .IsRequired();

            modelBuilder.Entity<Customer>()
                .Property(c => c.StateRegistration)
                .HasMaxLength(20);

            modelBuilder.Entity<Customer>()
                .Property(c => c.MunicipalityRegistration)
                .HasMaxLength(20);

            modelBuilder.Entity<Customer>()
                .Property(c => c.Suframa)
                .HasMaxLength(20);

            modelBuilder.Entity<Customer>()
                .Property(c => c.CellPhone)
                .HasMaxLength(20);

            modelBuilder.Entity<Customer>()
                .Property(c => c.PhoneNumbers)
                .HasMaxLength(20);

            modelBuilder.Entity<Customer>()
                .Property(c => c.AddressNumber)
                .HasMaxLength(20);

            modelBuilder.Entity<Customer>()
                .Property(c => c.AddressComplement)
                .HasMaxLength(300);

            modelBuilder.Entity<Customer>()
                .Property(c => c.Observation)
                .HasMaxLength(300);         

            modelBuilder.Entity<Customer>()
                .HasOne(c => c.Company)
                .WithMany()
                .HasForeignKey(c => c.CompanyId);

            return modelBuilder;
        }
    }
}
