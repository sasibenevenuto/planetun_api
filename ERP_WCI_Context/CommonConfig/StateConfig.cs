using ERP_WCI_Model.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_WCI_Context.CommonConfig
{
    public static class StateConfig
    {
        public static ModelBuilder StateConfigModelBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<State>()
                .HasKey(c => c.StateId)                
                .HasName("PrimaryKey_StateId");

            modelBuilder.Entity<State>()
                .Property(c => c.Name)
                .HasMaxLength(300)
                .IsRequired();

            modelBuilder.Entity<State>()
                .Property(c => c.ExternalCode)
                .HasMaxLength(300)
                .IsRequired();

            return modelBuilder;
        }
    }
}
