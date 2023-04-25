using ERP_WCI_Model.Companies;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_WCI_Context.CompaniesConfig
{
    public static class CompanyConfig
    {
        public static ModelBuilder CompanyConfigModelBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
                .HasKey(c => c.CompanyId)
                .HasName("PrimaryKey_CompanyId");

            modelBuilder.Entity<Company>()
                .Property(c => c.TradingName)
                .HasMaxLength(300)
                .IsRequired();

            modelBuilder.Entity<Company>()
                .Property(c => c.CNPJ)
                .HasMaxLength(20);

            modelBuilder.Entity<Company>()
                .Property(c => c.StateRegistration)
                .HasMaxLength(20);

            modelBuilder.Entity<Company>()
                .Property(c => c.CNAE)
                .HasMaxLength(20);

            modelBuilder.Entity<Company>()
                .Property(c => c.MunicipalityRegistration)
                .HasMaxLength(20);

            modelBuilder.Entity<Company>()
                .Property(c => c.StateRegistrationReplaceTributary)
                .HasMaxLength(20);

            modelBuilder.Entity<Company>()
               .Property(c => c.LogoBase64)
               .HasMaxLength(int.MaxValue);

            modelBuilder.Entity<Company>()
             .HasMany(c => c.PhoneNumbers)
             .WithOne(t => t.Company);

            modelBuilder.Entity<Company>()
               .Property(c => c.AddressNumber)
               .HasMaxLength(20);

            modelBuilder.Entity<Company>()
               .Property(c => c.AddressComplement)
               .HasMaxLength(300);

            modelBuilder.Entity<Company>()
                .HasOne(a => a.Address)
                .WithMany()
                .HasForeignKey(a => a.AddressId);

            modelBuilder.Entity<Company>()
                .HasOne(c => c.Account)
                .WithMany()
                .HasForeignKey(c => c.AccountId)
                .HasPrincipalKey(s => s.AccountId);

            return modelBuilder;
        }
    }
}
