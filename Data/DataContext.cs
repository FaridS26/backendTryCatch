using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using test_tryCatch.Data.Models;

namespace test_tryCatch.Data;

public partial class DataContext : DbContext
{
    public DataContext()
    {
    }

    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("empleado_pkey");

            entity.ToTable("empleado");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(100)
                .HasColumnName("apellidos");
            entity.Property(e => e.Cedula)
                .HasMaxLength(15)
                .HasColumnName("cedula");
            entity.Property(e => e.Celular)
                .HasMaxLength(15)
                .HasColumnName("celular");
            entity.Property(e => e.CodigoEmpleado)
                .HasMaxLength(20)
                .HasColumnName("codigo_empleado");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Direccion).HasColumnName("direccion");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Nombres)
                .HasMaxLength(100)
                .HasColumnName("nombres");
            entity.Property(e => e.Rol)
                .HasMaxLength(20)
                .HasColumnName("rol");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tickets_pkey");

            entity.ToTable("tickets");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.Direccion).HasColumnName("direccion");
            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.Lat).HasColumnName("lat");
            entity.Property(e => e.Lng).HasColumnName("lng");
            entity.Property(e => e.Priority)
                .HasMaxLength(20)
                .HasColumnName("priority");
            entity.Property(e => e.ServiceDate).HasColumnName("service_date");
            entity.Property(e => e.ServiceType)
                .HasMaxLength(100)
                .HasColumnName("service_type");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("usuarios_pkey");

            entity.ToTable("usuarios");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(100)
                .HasColumnName("apellidos");
            entity.Property(e => e.Cedula)
                .HasMaxLength(15)
                .HasColumnName("cedula");
            entity.Property(e => e.Celular)
                .HasMaxLength(15)
                .HasColumnName("celular");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Direccion).HasColumnName("direccion");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.FechaNacimiento).HasColumnName("fecha_nacimiento");
            entity.Property(e => e.Lat).HasColumnName("lat");
            entity.Property(e => e.Lng).HasColumnName("lng");
            entity.Property(e => e.Nombres)
                .HasMaxLength(100)
                .HasColumnName("nombres");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
