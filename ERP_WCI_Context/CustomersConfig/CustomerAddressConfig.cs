using ERP_WCI_Model.Customers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_WCI_Context.CustomersConfig
{
    public static class CustomerAddressConfig
    {
        public static ModelBuilder CustomerAddressConfigModelBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerAddress>()
                .HasKey(c => c.CustomerAddressId)
                .HasName("PrimaryKey_CustomerAddressId");

            modelBuilder.Entity<CustomerAddress>()
                .HasOne(a => a.Address)
                .WithMany()
                .HasForeignKey(a => a.AddressId);

            modelBuilder.Entity<CustomerAddress>()
                .HasOne(c => c.Customer)
                .WithMany()
                .HasForeignKey(c => c.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            return modelBuilder;
        }
    }
}
