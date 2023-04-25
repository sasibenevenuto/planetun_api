using ERP_WCI_Model.Common;
using ERP_WCI_Model.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_WCI_Context.IdentityConfig
{
    public static class Profile_x_ClaimConfig
    {
        public static ModelBuilder Profile_x_ClaimConfigModelBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Profile_x_Claim>()
                .HasKey(c => c.Profile_x_ClaimId)
                .HasName("PrimaryKey_Profile_x_ClaimConfigId");

            modelBuilder.Entity<Profile_x_Claim>()               
                .HasOne(c => c.Profile)
                .WithMany()
                .HasForeignKey(c => c.ProfileId);

            modelBuilder.Entity<Profile_x_Claim>()
               .HasOne(c => c.WciClaim)
               .WithMany()
               .HasForeignKey(c => c.WciClaimId);

            return modelBuilder;
        }
    }
}
