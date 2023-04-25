using ERP_WCI_Model.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_WCI_Context.CommonConfig
{
    public static class PersonalInformationConfig
    {
        public static ModelBuilder PersonalInformationConfigModelBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonalInformation>()
                .HasKey(c => c.PersonalInformationId)
                .HasName("PrimaryKey_PersonalInformationId");

            modelBuilder.Entity<PersonalInformation>()
                .Property(c => c.Name)
                .HasMaxLength(300)
                .IsRequired();

            modelBuilder.Entity<PersonalInformation>()
                .Property(c => c.IndividualResistration)
                .HasMaxLength(20);            

            modelBuilder.Entity<PersonalInformation>()
                .Property(c => c.AddressNumber)
                .HasMaxLength(20);

            modelBuilder.Entity<PersonalInformation>()
                .Property(c => c.AddressComplement)
                .HasMaxLength(300);

            modelBuilder.Entity<PersonalInformation>()
                .HasOne(c => c.Company)
                .WithMany()
                .HasForeignKey(c => c.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PersonalInformation>()
               .HasMany(c => c.PhoneNumbers)
               .WithOne(t => t.PersonalInformation);

            modelBuilder.Entity<PersonalInformation>()
                .HasOne(a => a.Address)
                .WithMany()
                .HasForeignKey(a => a.AddressId)
                .OnDelete(DeleteBehavior.Restrict);

            return modelBuilder;
        }
    }
}
