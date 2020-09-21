using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Dto.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Lib.DAL.Mapping
{
    class TeachersMapping : IEntityTypeConfiguration<Teachers>
    {
        public void Configure(EntityTypeBuilder<Teachers> builder)
        {
            builder.ToTable("Teacher","dbo");
            builder.HasKey(x => x.TeacherId);
            builder.Property(x => x.TeacherName);
            builder.Property(x => x.TeacherEmail);
            builder.Property(x => x.TeacherPassword);
            builder.Property(x => x.DateOfBirth).HasColumnType("Date");
        }
    }
}
