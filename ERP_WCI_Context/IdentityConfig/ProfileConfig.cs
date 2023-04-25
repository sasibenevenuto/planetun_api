using ERP_WCI_Model.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_WCI_Context.IdentityConfig
{
    public static class ProfileConfig
    {
        public static ModelBuilder ProfileConfigModelBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Profile>()
                .HasKey(c => c.ProfileId)
                .HasName("PrimaryKey_ProfileId");

            modelBuilder.Entity<Profile>()
               .Property(c => c.Description)
               .HasMaxLength(300)
               .IsRequired();

            return modelBuilder;
        }
    }
}
