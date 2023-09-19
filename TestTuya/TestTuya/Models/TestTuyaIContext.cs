using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TestTuya.Models
{
    public partial class TestTuyaIContext : DbContext
    {
        public TestTuyaIContext()
        {
        }

        public TestTuyaIContext(DbContextOptions<TestTuyaIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderDetail> OrderDetails { get; set; } = null!;

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source=FILIPE\\SQLEXPRESS;Database=TestTuyaI;Integrated Security=false;User ID=sa;Password=F3l1p3.23*;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Apellidos)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Identificacion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.CustomerId).HasColumnName("customerId");

                entity.Property(e => e.FechaOrden).HasColumnType("datetime");

                entity.Property(e => e.ValorOrden)
                    .HasColumnType("money")
                    .HasColumnName("valorOrden");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Customers");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.DescripcionProducto)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("descripcionProducto");

                entity.Property(e => e.IdProducto).HasColumnName("idProducto");

                entity.Property(e => e.Total).HasColumnType("money");

                entity.Property(e => e.ValorUnitario)
                    .HasColumnType("money")
                    .HasColumnName("valorUnitario");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_OrderDetails_Orders");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
