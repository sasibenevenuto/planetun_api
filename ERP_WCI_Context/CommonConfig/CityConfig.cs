using ERP_WCI_Model.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_WCI_Context.CommonConfig
{
    public static class CityConfig
    {
        public static ModelBuilder CityConfigModelBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .HasKey(c => c.CityId)
                .HasName("PrimaryKey_CityId");

            modelBuilder.Entity<City>()
                .Property(c => c.Name)
                .HasMaxLength(300)
                .IsRequired();

            modelBuilder.Entity<City>()
                .Property(c => c.ExternalCode)
                .HasMaxLength(300)
                .IsRequired();

            modelBuilder.Entity<City>()
                .HasOne(c => c.State)
                .WithMany()
                .HasForeignKey(c => c.StateId)
                .HasPrincipalKey(s => s.StateId);

            return modelBuilder;
        }
    }
}
