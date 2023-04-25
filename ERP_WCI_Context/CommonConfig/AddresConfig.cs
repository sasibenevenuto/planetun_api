using ERP_WCI_Model;
using ERP_WCI_Model.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_WCI_Context.CommonConfig
{
    public static class AddressConfig
    {
        public static ModelBuilder AddressConfigModelBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                .HasKey(a => a.AddressId)
                .HasName("PrimaryKey_AddressId");

            modelBuilder.Entity<Address>()
                .Property(a => a.PostalCode)
                .HasMaxLength(10)
                .IsRequired();

            modelBuilder.Entity<Address>()
                .Property(a => a.AddressStreet)
                .HasMaxLength(300)
                .IsRequired();

            modelBuilder.Entity<Address>()
                .Property(a => a.Neighborhood)
                .HasMaxLength(300)
                .IsRequired();

            modelBuilder.Entity<Address>()
                .HasOne(a => a.State)
                .WithMany()
                .HasForeignKey(a => a.StateId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Address>()
                .HasOne(a => a.City)
                .WithMany()
                .HasForeignKey(a => a.CityId)
                .OnDelete(DeleteBehavior.Restrict); 

            return modelBuilder;
        }
    }
}
