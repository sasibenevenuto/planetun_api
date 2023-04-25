using ERP_WCI_Model.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_WCI_Context.CommonConfig
{
    public static class AccountConfig
    {
        public static ModelBuilder AccountConfigModelBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .HasKey(c => c.AccountId)
                .HasName("PrimaryKey_AccountId");

            modelBuilder.Entity<Account>()
                .Property(c => c.EmailAccount)
                .HasMaxLength(300)
                .IsRequired();

            modelBuilder.Entity<Account>()
                .Property(c => c.TypeAccount)
                .IsRequired();

            modelBuilder.Entity<Account>()
                .Property(c => c.CompanyActived);         

            return modelBuilder;
        }
    }
}
