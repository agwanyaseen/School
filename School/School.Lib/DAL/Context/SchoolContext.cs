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

        public SchoolContext(DbContextOptions<SchoolContext> options): base(options)
        {
           
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserRoleMapping());
            modelBuilder.ApplyConfiguration(new UserTypeMapping());
            modelBuilder.ApplyConfiguration(new UsersMapping());
            base.OnModelCreating(modelBuilder);
        }

    }
}
