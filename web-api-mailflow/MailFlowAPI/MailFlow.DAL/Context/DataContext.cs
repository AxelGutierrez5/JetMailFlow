using System;
using System.Collections.Generic;
using MailFlow.DAL;
using Microsoft.EntityFrameworkCore;
using MailFlow.BE.Models;


namespace MailFlow.DAL.Context;

public partial class DataContext : DbContext
{
    public DataContext()
    {
    }

    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Campania> Campania { get; set; }

    public virtual DbSet<Contacto> Contactos { get; set; }

    public virtual DbSet<Envio> Envios { get; set; }

    public virtual DbSet<Lista> Lista { get; set; }

    public virtual DbSet<Plantilla> Plantillas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Campania>(entity =>
        {
            entity.HasKey(e => e.CampaniaId);

            entity.Property(e => e.Creacion).HasColumnType("datetime");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaProgramada).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Lista).WithMany(p => p.Campania)
                .HasForeignKey(d => d.ListaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Campania_Lista");

            entity.HasOne(d => d.Plantilla).WithMany(p => p.Campania)
                .HasForeignKey(d => d.PlantillaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Campania_Plantilla");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Campania)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Campania_Usuario");
        });

        modelBuilder.Entity<Contacto>(entity =>
        {
            entity.ToTable("Contacto");

            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Creacion).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasMany(d => d.Lista).WithMany(p => p.Contactos)
                .UsingEntity<Dictionary<string, object>>(
                    "ListaContacto",
                    r => r.HasOne<Lista>().WithMany()
                        .HasForeignKey("ListaId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_ListaContacto_Lista"),
                    l => l.HasOne<Contacto>().WithMany()
                        .HasForeignKey("ContactoId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_ListaContacto_Contacto"),
                    j =>
                    {
                        j.HasKey("ContactoId", "ListaId").HasName("PK_ContactoLista");
                        j.ToTable("ListaContacto");
                    });
        });

        modelBuilder.Entity<Envio>(entity =>
        {
            entity.HasKey(e => e.EnvioId).HasName("PK_CampaniaContacto_1");

            entity.ToTable("Envio");

            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaEnvio).HasColumnType("datetime");

            entity.HasOne(d => d.Campania).WithMany(p => p.Envios)
                .HasForeignKey(d => d.CampaniaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Envio_Campania");

            entity.HasOne(d => d.Contacto).WithMany(p => p.Envios)
                .HasForeignKey(d => d.ContactoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Envio_Contacto");
        });

        modelBuilder.Entity<Lista>(entity =>
        {
            entity.HasKey(e => e.ListaId);

            entity.Property(e => e.Creacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Plantilla>(entity =>
        {
            entity.HasKey(e => e.PlantillaId).HasName("PK_TemplateEmail");

            entity.ToTable("Plantilla");

            entity.Property(e => e.Asunto).IsUnicode(false);
            entity.Property(e => e.ContenidoHtml)
                .IsUnicode(false)
                .HasColumnName("ContenidoHTML");
            entity.Property(e => e.Creacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Usuario).WithMany(p => p.Plantillas)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TemplateEmail_Usuario");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.ToTable("Usuario");

            entity.Property(e => e.Creacion).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NombreCompleto)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password).IsUnicode(false);
            entity.Property(e => e.Rol)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
