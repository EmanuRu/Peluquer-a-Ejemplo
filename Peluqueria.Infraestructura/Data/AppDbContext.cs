using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Peluqueria.Infraestructura.Data.Models;

namespace Peluqueria.Infraestructura.Data
{
    public partial class AppDbContext : DbContext
    {//AppDBContext comunica el sistema con la bd
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        //creacion de los DbSet
        public virtual DbSet<ClienteEntity> Clientes { get; set; } = null!;
        public virtual DbSet<EstadoReservaEntity> EstadoReservas { get; set; } = null!;
        public virtual DbSet<ProfesionalEntity> Profesionals { get; set; } = null!;
        public virtual DbSet<ReservaEntity> Reservas { get; set; } = null!;
        public virtual DbSet<ServicioEntity> Servicios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=.;database=PeluqueriaDB;Trusted_Connection=true;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClienteEntity>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__Cliente__D59466426ABF7202");

                entity.Property(e => e.FechaRegistro).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Visible).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<EstadoReservaEntity>(entity =>
            {
                entity.HasKey(e => e.IdEstado)
                    .HasName("PK__EstadoRe__FBB0EDC1D7A574EE");

                entity.Property(e => e.Visible).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<ProfesionalEntity>(entity =>
            {
                entity.HasKey(e => e.IdProfesional)
                    .HasName("PK__Profesio__BC490D0A04629A5E");

                entity.Property(e => e.Visible).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<ReservaEntity>(entity =>
            {
                entity.HasKey(e => e.IdReserva)
                    .HasName("PK__Reserva__0E49C69DA4793417");

                entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdEstado).HasDefaultValueSql("((1))");

                entity.Property(e => e.Visible).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Reservas)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reserva_Cliente");

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.Reservas)
                    .HasForeignKey(d => d.IdEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reserva_Estado");

                entity.HasOne(d => d.IdProfesionalNavigation)
                    .WithMany(p => p.Reservas)
                    .HasForeignKey(d => d.IdProfesional)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reserva_Profesional");

                entity.HasOne(d => d.IdServicioNavigation)
                    .WithMany(p => p.Reservas)
                    .HasForeignKey(d => d.IdServicio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reserva_Servicio");
            });

            modelBuilder.Entity<ServicioEntity>(entity =>
            {
                entity.HasKey(e => e.IdServicio)
                    .HasName("PK__Servicio__2DCCF9A2BACFBC57");

                entity.Property(e => e.Visible).HasDefaultValueSql("((1))");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
