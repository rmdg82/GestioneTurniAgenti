using GestioneTurniAgenti.Server.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GestioneTurniAgenti.Server.Contexts
{
    public class GestioneTurniDbContext : DbContext
    {
        public DbSet<Agente> Agenti { get; set; }
        public DbSet<Reparto> Reparti { get; set; }
        public DbSet<Turno> Turni { get; set; }
        public DbSet<Evento> Eventi { get; set; }

        public GestioneTurniDbContext(DbContextOptions<GestioneTurniDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Automatically adjourn CreatedOn and UpdateOn fields.
        /// </summary>
        /// <returns></returns>
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            var utcNow = DateTime.UtcNow;

            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is BaseEntity entity)
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            entity.CreatedOn = utcNow;
                            entity.UpdatedOn = utcNow;
                            break;

                        case EntityState.Modified:
                            entry.Property("CreatedOn").IsModified = false;
                            entity.UpdatedOn = utcNow;
                            break;
                    }
            }
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Agente
            builder.Entity<Agente>()
                .Property(a => a.Matricola)
                .HasMaxLength(8)
                .IsFixedLength()
                .IsRequired();

            builder.Entity<Agente>()
                .HasIndex(a => a.Matricola)
                .IsUnique();

            builder.Entity<Agente>()
                .Property(a => a.Nome)
                .HasMaxLength(30)
                .IsRequired();

            builder.Entity<Agente>()
                .Property(a => a.Cognome)
                .HasMaxLength(30)
                .IsRequired();

            builder.Entity<Agente>()
                .HasOne(a => a.Reparto)
                .WithMany(r => r.Agenti);

            // Reparto
            builder.Entity<Reparto>()
                .Property(r => r.Nome)
                .HasMaxLength(50)
                .IsRequired();

            // Turno
            builder.Entity<Turno>()
                .Property(t => t.Note)
                .HasMaxLength(500);

            // Evento
            builder.Entity<Evento>()
                .Property(e => e.Nome)
                .HasMaxLength(50)
                .IsRequired();

            builder.Entity<Evento>()
                .HasIndex(e => e.Nome)
                .IsUnique();

            builder.Entity<Evento>()
                .HasCheckConstraint("CK_Eventi_InizioPrecedenteFine", "Inizio <= Fine");

            SeedInitialData(builder);
        }

        private static void SeedInitialData(ModelBuilder builder)
        {
            builder.Entity<Reparto>()
                .HasData(
                new Reparto
                {
                    Id = new Guid("144913db-12eb-4751-ab94-be4b26b777e1"),
                    Nome = "Reparto1",
                },
                new Reparto
                {
                    Id = new Guid("7307b34f-052c-4ef1-b0c3-fb6b3ffe8f3f"),
                    Nome = "Reparto2"
                },
                new Reparto
                {
                    Id = new Guid("7f2fb853-4aab-43d3-9448-d9f3edbc793c"),
                    Nome = "Reparto3"
                });

            builder.Entity<Agente>()
                .HasData(
                new Agente
                {
                    Id = Guid.NewGuid(),
                    Nome = "Mario",
                    Cognome = "Rossi",
                    Matricola = "123456AB",
                    RepartoId = new Guid("7f2fb853-4aab-43d3-9448-d9f3edbc793c")
                },
                new Agente
                {
                    Id = Guid.NewGuid(),
                    Nome = "Antonio",
                    Cognome = "Bianchi",
                    Matricola = "789012CD",
                    RepartoId = new Guid("7f2fb853-4aab-43d3-9448-d9f3edbc793c")
                },
                new Agente
                {
                    Id = Guid.NewGuid(),
                    Nome = "Pietro",
                    Cognome = "Verdi",
                    Matricola = "135267EF",
                    RepartoId = new Guid("144913db-12eb-4751-ab94-be4b26b777e1")
                },
                new Agente
                {
                    Id = Guid.NewGuid(),
                    Nome = "Antonio",
                    Cognome = "Blu",
                    Matricola = "564922HJ",
                    RepartoId = new Guid("7307b34f-052c-4ef1-b0c3-fb6b3ffe8f3f")
                },
                new Agente
                {
                    Id = Guid.NewGuid(),
                    Nome = "Paolo",
                    Cognome = "Viola",
                    Matricola = "789012FG",
                    RepartoId = new Guid("7307b34f-052c-4ef1-b0c3-fb6b3ffe8f3f")
                },
                new Agente
                {
                    Id = Guid.NewGuid(),
                    Nome = "Guido",
                    Cognome = "Giallo",
                    Matricola = "123432HG",
                    RepartoId = new Guid("144913db-12eb-4751-ab94-be4b26b777e1")
                });

            builder.Entity<Evento>()
                .HasData(
                new Evento
                {
                    Id = new Guid("95146179-3589-4a7a-916e-0d696574273e"),
                    Nome = "Evento1",
                    Inizio = new DateTime(2020, 01, 01),
                    Fine = new DateTime(2021, 01, 01)
                },
                new Evento
                {
                    Id = new Guid("0adc2d1c-7f8d-41a7-8a70-ac0b498ba4f9"),
                    Nome = "Evento2",
                    Inizio = new DateTime(2021, 01, 01),
                    Fine = new DateTime(2021, 06, 01)
                });
        }
    }
}