using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Dto.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Lib.DAL.Mapping
{
    public class StudentsMapping : IEntityTypeConfiguration<Students>
    {
        public void Configure(EntityTypeBuilder<Students> builder)
        {
            builder.ToTable("Student","dbo");
            builder.HasKey(x => x.StudentId);
            builder.Property(x => x.StudentName).IsRequired();
            builder.Property(x => x.DateOfBirth).HasColumnType("date");
        }
    }
}
