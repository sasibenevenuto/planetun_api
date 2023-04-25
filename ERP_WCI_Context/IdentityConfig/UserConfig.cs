using ERP_WCI_Model.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_WCI_Context.IdentityConfig
{
    public class UserConfig
    {
        public static ModelBuilder UserConfigModelBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(c => c.Id)
                .HasName("PrimaryKey_UserId");

            modelBuilder.Entity<User>()
                .Property(c => c.UserName)
                .HasMaxLength(300)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(c => c.Name)
                .HasMaxLength(300)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(c => c.CPF)
                .HasMaxLength(30)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(c => c.LoginToken)
                .HasMaxLength(int.MaxValue)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(c => c.PasswordHash)
                .HasMaxLength(500)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(c => c.Email)
                .HasMaxLength(30)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(c => c.EmailConfirmed)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(c => c.SecurityStamp)
                .HasMaxLength(300)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(c => c.LockoutEnabled)                
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(c => c.AccessFailedCount)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(c => c.Active)
                .IsRequired();

            modelBuilder.Entity<User>()
               .Property(c => c.CreateDate)
               .IsRequired();

            modelBuilder.Entity<User>()
               .Property(c => c.ModifieldDate)
               .IsRequired();

            return modelBuilder;
        }
    }
}
