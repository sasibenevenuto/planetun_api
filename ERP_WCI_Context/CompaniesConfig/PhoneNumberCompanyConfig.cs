using ERP_WCI_Model.Companies;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_WCI_Context.CompaniesConfig
{
    public class PhoneNumberCompanyConfig
    {
        public static ModelBuilder PhoneNumberCompanyConfigModelBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PhoneNumberCompany>()
                .HasKey(c => c.PhoneNumberCompanyId)
                .HasName("PrimaryKey_PhoneNumberCompanyId");

            modelBuilder.Entity<PhoneNumberCompany>()
                .Property(c => c.TypePhone);

            modelBuilder.Entity<PhoneNumberCompany>()
                .Property(c => c.Number)
                .HasMaxLength(20);

            return modelBuilder;
        }
    }
}
