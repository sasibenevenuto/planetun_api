using ERP_WCI_Model.Common;
using ERP_WCI_Model.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_WCI_Context.IdentityConfig
{
    public static class WciClaimConfig
    {
        public static ModelBuilder WciClaimsConfigModelBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WciClaim>()
                .HasKey(c => c.WciClaimId)
                .HasName("PrimaryKey_WciClaimId");

            modelBuilder.Entity<WciClaim>()
               .Property(c => c.NickName)
               .HasMaxLength(300)
               .IsRequired();

            modelBuilder.Entity<WciClaim>()
                .Property(c => c.NameType)
                .HasMaxLength(300)
                .IsRequired();

            modelBuilder.Entity<WciClaim>()
                .Property(c => c.Value)
                .HasMaxLength(300)
                .IsRequired();           

            return modelBuilder;
        }
    }
}
