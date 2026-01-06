using System;
using System.Collections.Generic;
using MailFlow.DAL;
using Microsoft.EntityFrameworkCore;

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

    public virtual DbSet<CampaniaContacto> CampaniaContactos { get; set; }

    public virtual DbSet<Campania> Campania { get; set; }

    public virtual DbSet<Contacto> Contactos { get; set; }

    public virtual DbSet<ListaContacto> Lista { get; set; }

    public virtual DbSet<TemplateEmail> TemplateEmails { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CampaniaContacto>(entity =>
        {
            entity.HasKey(e => new { e.CampaniaId, e.ContactoId });

            entity.ToTable("CampaniaContacto");

            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Campania).WithMany(p => p.CampaniaContactos)
                .HasForeignKey(d => d.CampaniaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CampaniaContacto_Campania");

            entity.HasOne(d => d.Contacto).WithMany(p => p.CampaniaContactos)
                .HasForeignKey(d => d.ContactoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CampaniaContacto_Contacto");
        });

        modelBuilder.Entity<Campania>(entity =>
        {
            entity.HasKey(e => e.CamapaniaId);

            entity.Property(e => e.CamapaniaId).ValueGeneratedNever();
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaEnvio).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Usuario).WithMany(p => p.Campania)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Campania_Usuario");
        });

        modelBuilder.Entity<Contacto>(entity =>
        {
            entity.HasKey(e => e.ContactotId);

            entity.ToTable("Contacto");

            entity.Property(e => e.ContactotId).ValueGeneratedNever();
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Creacion).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasMany(d => d.Lista).WithMany(p => p.Contactos)
                .UsingEntity<Dictionary<string, object>>(
                    "ContactoLista",
                    r => r.HasOne<ListaContacto>().WithMany()
                        .HasForeignKey("ListaId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_ContactoLista_Lista"),
                    l => l.HasOne<Contacto>().WithMany()
                        .HasForeignKey("ContactoId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_ContactoLista_Contacto"),
                    j =>
                    {
                        j.HasKey("ContactoId", "ListaId");
                        j.ToTable("ContactoLista");
                    });
        });

        modelBuilder.Entity<ListaContacto>(entity =>
        {
            entity.HasKey(e => e.ListaId);

            entity.Property(e => e.ListaId).ValueGeneratedNever();
            entity.Property(e => e.Creacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TemplateEmail>(entity =>
        {
            entity.HasKey(e => e.TemplateId);

            entity.ToTable("TemplateEmail");

            entity.Property(e => e.TemplateId).ValueGeneratedNever();
            entity.Property(e => e.Asunto).IsUnicode(false);
            entity.Property(e => e.ContenidoHtml)
                .IsUnicode(false)
                .HasColumnName("ContenidoHTML");
            entity.Property(e => e.Creacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Usuario).WithMany(p => p.TemplateEmails)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TemplateEmail_Usuario");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.ToTable("Usuario");

            entity.Property(e => e.UsuarioId).ValueGeneratedNever();
            entity.Property(e => e.Creacion)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NombreCompleto)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password).IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
