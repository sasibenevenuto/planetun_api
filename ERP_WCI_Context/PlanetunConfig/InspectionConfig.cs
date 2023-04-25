using ERP_WCI_Model.Identity;
using ERP_WCI_Model.Planetun;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_WCI_Context.PlanetunConfig
{
    public static class InspectionConfig
    {
        public static ModelBuilder InspectionConfigModelBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inspection>()
                .HasKey(c => c.InspectionId)
                .HasName("PrimaryKey_InspectionId");

            modelBuilder.Entity<Inspection>()
               .Property(c => c.CompanyId)
               .IsRequired();

            modelBuilder.Entity<Inspection>()
                .Property(c => c.BrokerCode)
                .HasMaxLength(300);

            modelBuilder.Entity<Inspection>()
                .Property(c => c.ProductCode)
                .HasMaxLength(300);

            modelBuilder.Entity<Inspection>()
                .Property(c => c.ProductName)
                .HasMaxLength(300);

            modelBuilder.Entity<Inspection>()
                .Property(c => c.InspectionNumber)
                .HasMaxLength(300);

            return modelBuilder;
        }
    }
}
