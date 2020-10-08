using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Dto.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Lib.DAL.Mapping
{
    public class DivisionMapping : IEntityTypeConfiguration<Division>
    {
        public void Configure(EntityTypeBuilder<Division> builder)
        {
            builder.ToTable("Division", "dbo");
            builder.HasKey(x => x.DivisionId);
            builder.Property(x => x.DivisionName).HasColumnName("Division").IsRequired();
        }
    }
}
