using System;
using System.Collections.Generic;
using System.Text;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using Orders.Domain.Entities;

namespace Orders.Infra.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Import> Imports { get; set; }
        public DbSet<ImportItem> ImportItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();

            modelBuilder.Entity<Import>().ToTable("Import");
            modelBuilder.Entity<Import>().Property(import => import.Id);
            modelBuilder.Entity<Import>().Property(import => import.FileExtension).HasColumnName("FileExtension").IsRequired();
            modelBuilder.Entity<Import>().Property(import => import.Instant).HasColumnName("Instant").IsRequired();

            modelBuilder.Entity<Import>()
                .HasMany(import => import.Items)
                .WithOne(importItem => importItem.Import)
                .IsRequired();

            modelBuilder.Entity<ImportItem>().ToTable("ImportItem");
            modelBuilder.Entity<ImportItem>().Property(importItem => importItem.Id);
            modelBuilder.Entity<ImportItem>().Property(importItem => importItem.Line).HasColumnName("Line").IsRequired();
            modelBuilder.Entity<ImportItem>().Property(importItem => importItem.Name).HasColumnName("Name").HasMaxLength(50).HasColumnType("varchar(50)").IsRequired();
            modelBuilder.Entity<ImportItem>().Property(importItem => importItem.DeliveryDate).HasColumnName("DeliveryDate").IsRequired();
            modelBuilder.Entity<ImportItem>().Property(importItem => importItem.Quantity).HasColumnName("Quantity").IsRequired();
            modelBuilder.Entity<ImportItem>().Property(importItem => importItem.UnitPrice).HasColumnName("UnitPrice").HasPrecision(18, 2).IsRequired();









        }
    }
}
