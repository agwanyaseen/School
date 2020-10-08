using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Dto.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Lib.DAL.Mapping
{
    public class ClassMapping : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.ToTable("Class", "dbo");
            builder.HasKey(x => x.ClassId);
            builder.HasMany(x => x.StudentsClass);
        }
    }
}
