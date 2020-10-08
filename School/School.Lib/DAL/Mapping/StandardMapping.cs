using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Dto.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Lib.DAL.Mapping
{
    public class StandardMapping : IEntityTypeConfiguration<Standard>
    {
        public void Configure(EntityTypeBuilder<Standard> builder)
        {
            builder.ToTable("Standard", "dbo");
            builder.HasKey(x => x.StandardId);
            builder.Property(x => x.StandardName).IsRequired();
        }
    }
}
