using ERP_WCI_Model.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_WCI_Context.CommonConfig
{
    public class PhoneNumberPersonalInformationConfig
    {
        public static ModelBuilder PhoneNumberPersonalInformationConfigModelBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PhoneNumberPersonalInformation>()
                .HasKey(c => c.PhoneNumberPersonalInformationId)
                .HasName("PrimaryKey_PhoneNumberPersonalInformationId");

            modelBuilder.Entity<PhoneNumberPersonalInformation>()
                .Property(c => c.TypePhone);

            modelBuilder.Entity<PhoneNumberPersonalInformation>()
                .Property(c => c.Number)
                .HasMaxLength(20);

            return modelBuilder;
        }
    }
}
