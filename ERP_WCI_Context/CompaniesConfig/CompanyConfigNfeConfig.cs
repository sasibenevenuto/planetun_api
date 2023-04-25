using ERP_WCI_Model.Companies;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_WCI_Context.CompaniesConfig
{
    public static class CompanyConfigNfeConfig
    {
        public static ModelBuilder CompanyConfigNfeConfigModelBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompanyConfigNfe>()
                .HasKey(c => c.CompanyConfigNFeId)
                .HasName("PrimaryKey_CompanyConfigNFeId");

            modelBuilder.Entity<CompanyConfigNfe>()
                .Property(c => c.CurrentNumberNfe)
                .IsRequired();

            modelBuilder.Entity<CompanyConfigNfe>()
                .Property(c => c.VersionNfe)
                .HasMaxLength(20)
                .IsRequired();

            modelBuilder.Entity<CompanyConfigNfe>()
                .HasOne(c => c.Company)
                .WithOne(c => c.CompanyConfigNfe)
                .HasForeignKey<CompanyConfigNfe>(c => c.CompanyId);

            return modelBuilder;
        }
    }
}
