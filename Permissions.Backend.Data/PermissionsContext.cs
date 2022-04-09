using Microsoft.EntityFrameworkCore;
using Permissions.Backend.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Permissions.Backend.Data
{
    public class PermissionsContext:DbContext
    {
        public DbSet<Permission> Permissions { get; set; }

        public DbSet<PermissionType> PermissionsType { get; set; }

        public PermissionsContext(DbContextOptions<PermissionsContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Permission>(entity =>
            {
                entity.ToTable("permissions", "permissionsdb");

                entity.HasKey(p => p.Id);

                entity.HasIndex(p => p.Id);

                entity.Property(p => p.Id).HasColumnName("id").IsRequired();

                entity.Property(p => p.Name).HasColumnName("employee_name").IsRequired();

                entity.Property(p => p.LastName).HasColumnName("employee_last_name").IsRequired();

                entity.Property(p => p.Date).HasColumnName("date").IsRequired();

                entity.Property(p => p.PermissionTypeId).HasColumnName("permissions_type_id").IsRequired();

            });


            modelBuilder.Entity<PermissionType>(entity =>
            {
                entity.ToTable("permissions_type", "permissionsdb");

                entity.HasKey(pt => pt.Id);

                entity.HasIndex(pt => pt.Id);

                entity.Property(pt => pt.Id).HasColumnName("id").IsRequired();

                entity.Property(pt => pt.Description).HasColumnName("description").IsRequired();

            });
        }
    }
}
