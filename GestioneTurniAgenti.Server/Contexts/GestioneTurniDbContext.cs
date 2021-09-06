using GestioneTurniAgenti.Server.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GestioneTurniAgenti.Server.Contexts
{
    public class GestioneTurniDbContext : IdentityDbContext<IdentityUser>
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
            base.OnModelCreating(builder);

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
            SeedInitialIdentityData(builder);
        }

        private void SeedInitialIdentityData(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>()
                .HasData(
                new IdentityRole
                {
                    Id = "cb5e5f39-cd6b-4a7c-ba43-c132ed10902c",
                    Name = "Admin",
                    NormalizedName = "Admin".ToUpper()
                },
                new IdentityRole
                {
                    Id = "30f56dc1-007b-4bad-9e9c-8be1d8bc2a5f",
                    Name = "Super-Admin",
                    NormalizedName = "Super-Admin".ToUpper()
                });

            var passwordHasher = new PasswordHasher<IdentityUser>();

            builder.Entity<IdentityUser>()
                .HasData(
                new IdentityUser
                {
                    Id = "c4c1cfa4-b89a-47cc-9455-ece920e4fbec",
                    UserName = "123456AB",
                    NormalizedUserName = "123456AB".ToUpper(),
                    PasswordHash = passwordHasher.HashPassword(null, "123456AB")
                },
                new IdentityUser
                {
                    Id = "3c1088ae-a59e-4b17-8754-48cf84b420c6",
                    UserName = "789012CD",
                    NormalizedUserName = "789012CD".ToUpper(),
                    PasswordHash = passwordHasher.HashPassword(null, "789012CD")
                });

            builder.Entity<IdentityUserRole<string>>()
                .HasData(
                new IdentityUserRole<string>
                {
                    UserId = "c4c1cfa4-b89a-47cc-9455-ece920e4fbec",
                    RoleId = "cb5e5f39-cd6b-4a7c-ba43-c132ed10902c"
                },
                new IdentityUserRole<string>
                {
                    UserId = "3c1088ae-a59e-4b17-8754-48cf84b420c6",
                    RoleId = "30f56dc1-007b-4bad-9e9c-8be1d8bc2a5f"
                });
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
                    Id = new Guid("c4c1cfa4-b89a-47cc-9455-ece920e4fbec"),
                    Nome = "Mario",
                    Cognome = "Rossi",
                    Matricola = "123456AB",
                    RepartoId = new Guid("7f2fb853-4aab-43d3-9448-d9f3edbc793c")
                },
                new Agente
                {
                    Id = new Guid("3c1088ae-a59e-4b17-8754-48cf84b420c6"),
                    Nome = "Antonio",
                    Cognome = "Bianchi",
                    Matricola = "789012CD",
                    RepartoId = new Guid("7f2fb853-4aab-43d3-9448-d9f3edbc793c")
                },
                new Agente
                {
                    Id = new Guid("1d510fbc-9a24-4a60-810b-e8513851b1a1"),
                    Nome = "Pietro",
                    Cognome = "Verdi",
                    Matricola = "135267EF",
                    RepartoId = new Guid("144913db-12eb-4751-ab94-be4b26b777e1")
                },
                new Agente
                {
                    Id = new Guid("a77588e1-2416-4aa1-bbb9-3182c344a6ad"),
                    Nome = "Antonio",
                    Cognome = "Blu",
                    Matricola = "564922HJ",
                    RepartoId = new Guid("7307b34f-052c-4ef1-b0c3-fb6b3ffe8f3f")
                },
                new Agente
                {
                    Id = new Guid("2ee6d35d-551e-486f-956a-998bc23dd24c"),
                    Nome = "Paolo",
                    Cognome = "Viola",
                    Matricola = "789012FG",
                    RepartoId = new Guid("7307b34f-052c-4ef1-b0c3-fb6b3ffe8f3f")
                },
                new Agente
                {
                    Id = new Guid("50dc6495-494c-4262-8933-caf914bea25e"),
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