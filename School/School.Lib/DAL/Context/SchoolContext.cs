using Microsoft.EntityFrameworkCore;
using School.Dto.DomainModels;
using School.Lib.DAL.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Lib.DAL.Context
{
    public class SchoolContext : DbContext
    {
        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<UserType> UserTypes { get; set; }

        public DbSet<Users> Users { get; set; }

        public DbSet<Teachers> Teachers { get; set; }

        public DbSet<Standard> Standards { get; set; }

        public DbSet<Students> Students { get; set; }

        public DbSet<Division> Divisions { get; set; }

        public SchoolContext(DbContextOptions<SchoolContext> options): base(options)
        {
           
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserRoleMapping());
            modelBuilder.ApplyConfiguration(new UserTypeMapping());
            modelBuilder.ApplyConfiguration(new UsersMapping());
            modelBuilder.ApplyConfiguration(new TeachersMapping());
            modelBuilder.ApplyConfiguration(new StandardMapping());
            modelBuilder.ApplyConfiguration(new StudentsMapping());
            modelBuilder.ApplyConfiguration(new DivisionMapping());
            base.OnModelCreating(modelBuilder);
        }

    }
}
