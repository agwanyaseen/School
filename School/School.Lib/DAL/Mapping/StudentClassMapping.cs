using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Dto.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Lib.DAL.Mapping
{
    class StudentClassMapping : IEntityTypeConfiguration<StudentClass>
    {
        public void Configure(EntityTypeBuilder<StudentClass> builder)
        {
            builder.ToTable("StudentClass", "dbo");
            builder.HasKey(x=>x.StudentClassId);
            builder.Property(x => x.StudentId);
            builder.Property(x => x.ClassId);
        }
    }
}
