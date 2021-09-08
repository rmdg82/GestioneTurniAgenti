﻿// <auto-generated />
using System;
using GestioneTurniAgenti.Server.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GestioneTurniAgenti.Server.Migrations
{
    [DbContext(typeof(GestioneTurniDbContext))]
    partial class GestioneTurniDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("GestioneTurniAgenti.Server.Entities.Agente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Cognome")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.Property<string>("Matricola")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("TEXT")
                        .IsFixedLength(true);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.Property<Guid>("RepartoId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Matricola")
                        .IsUnique();

                    b.HasIndex("RepartoId");

                    b.ToTable("Agenti");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c4c1cfa4-b89a-47cc-9455-ece920e4fbec"),
                            Cognome = "Rossi",
                            Matricola = "123456AB",
                            Nome = "Mario",
                            RepartoId = new Guid("7f2fb853-4aab-43d3-9448-d9f3edbc793c")
                        },
                        new
                        {
                            Id = new Guid("3c1088ae-a59e-4b17-8754-48cf84b420c6"),
                            Cognome = "Bianchi",
                            Matricola = "789012CD",
                            Nome = "Antonio",
                            RepartoId = new Guid("7f2fb853-4aab-43d3-9448-d9f3edbc793c")
                        },
                        new
                        {
                            Id = new Guid("1d510fbc-9a24-4a60-810b-e8513851b1a1"),
                            Cognome = "Verdi",
                            Matricola = "135267EF",
                            Nome = "Pietro",
                            RepartoId = new Guid("144913db-12eb-4751-ab94-be4b26b777e1")
                        },
                        new
                        {
                            Id = new Guid("a77588e1-2416-4aa1-bbb9-3182c344a6ad"),
                            Cognome = "Blu",
                            Matricola = "564922HJ",
                            Nome = "Antonio",
                            RepartoId = new Guid("7307b34f-052c-4ef1-b0c3-fb6b3ffe8f3f")
                        },
                        new
                        {
                            Id = new Guid("2ee6d35d-551e-486f-956a-998bc23dd24c"),
                            Cognome = "Viola",
                            Matricola = "789012FG",
                            Nome = "Paolo",
                            RepartoId = new Guid("7307b34f-052c-4ef1-b0c3-fb6b3ffe8f3f")
                        },
                        new
                        {
                            Id = new Guid("50dc6495-494c-4262-8933-caf914bea25e"),
                            Cognome = "Giallo",
                            Matricola = "123432HG",
                            Nome = "Guido",
                            RepartoId = new Guid("144913db-12eb-4751-ab94-be4b26b777e1")
                        });
                });

            modelBuilder.Entity("GestioneTurniAgenti.Server.Entities.Evento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Fine")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Inizio")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Nome")
                        .IsUnique();

                    b.ToTable("Eventi");

                    b.HasCheckConstraint("CK_Eventi_InizioPrecedenteFine", "Inizio <= Fine");

                    b.HasData(
                        new
                        {
                            Id = new Guid("95146179-3589-4a7a-916e-0d696574273e"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fine = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Inizio = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nome = "Evento1",
                            UpdatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("0adc2d1c-7f8d-41a7-8a70-ac0b498ba4f9"),
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fine = new DateTime(2021, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Inizio = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nome = "Evento2",
                            UpdatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("GestioneTurniAgenti.Server.Entities.Reparto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Reparti");

                    b.HasData(
                        new
                        {
                            Id = new Guid("144913db-12eb-4751-ab94-be4b26b777e1"),
                            Nome = "Reparto1"
                        },
                        new
                        {
                            Id = new Guid("7307b34f-052c-4ef1-b0c3-fb6b3ffe8f3f"),
                            Nome = "Reparto2"
                        },
                        new
                        {
                            Id = new Guid("7f2fb853-4aab-43d3-9448-d9f3edbc793c"),
                            Nome = "Reparto3"
                        });
                });

            modelBuilder.Entity("GestioneTurniAgenti.Server.Entities.Turno", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("AgenteId")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Data")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("EventoId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Note")
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AgenteId");

                    b.HasIndex("EventoId");

                    b.ToTable("Turni");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "cb5e5f39-cd6b-4a7c-ba43-c132ed10902c",
                            ConcurrencyStamp = "9637cfc7-c078-4e01-a198-3ecc7b5cbdb4",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "30f56dc1-007b-4bad-9e9c-8be1d8bc2a5f",
                            ConcurrencyStamp = "32d15f30-a654-4364-93ee-25aa36d14892",
                            Name = "Super-Admin",
                            NormalizedName = "SUPER-ADMIN"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = "c4c1cfa4-b89a-47cc-9455-ece920e4fbec",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "0d0b2238-4863-4d86-ac89-ca52983f220f",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedUserName = "123456AB",
                            PasswordHash = "AQAAAAEAACcQAAAAEBhCzSjp9Xitqv6LXPb2I01Y0LfEv+ZTqsk2Widllwynhg5Qi8ZU3cDdymz/h+TO6Q==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "9b5f1901-7323-460d-82ea-a68b9a149a55",
                            TwoFactorEnabled = false,
                            UserName = "123456AB"
                        },
                        new
                        {
                            Id = "3c1088ae-a59e-4b17-8754-48cf84b420c6",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "23187f43-9ef7-41df-9292-a79d9e4e05fc",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedUserName = "789012CD",
                            PasswordHash = "AQAAAAEAACcQAAAAEGf1TDH+2froD1Ik9pGoCRX8feTVHfRH5YopiQ3p7fhb+vLHgCi2PBLiHreTHhAaMA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "da55d106-8bad-48e6-aa75-817c48fa09f4",
                            TwoFactorEnabled = false,
                            UserName = "789012CD"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");

                    b.HasData(
                        new
                        {
                            UserId = "c4c1cfa4-b89a-47cc-9455-ece920e4fbec",
                            RoleId = "cb5e5f39-cd6b-4a7c-ba43-c132ed10902c"
                        },
                        new
                        {
                            UserId = "3c1088ae-a59e-4b17-8754-48cf84b420c6",
                            RoleId = "30f56dc1-007b-4bad-9e9c-8be1d8bc2a5f"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("GestioneTurniAgenti.Server.Entities.Agente", b =>
                {
                    b.HasOne("GestioneTurniAgenti.Server.Entities.Reparto", "Reparto")
                        .WithMany("Agenti")
                        .HasForeignKey("RepartoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reparto");
                });

            modelBuilder.Entity("GestioneTurniAgenti.Server.Entities.Turno", b =>
                {
                    b.HasOne("GestioneTurniAgenti.Server.Entities.Agente", "Agente")
                        .WithMany()
                        .HasForeignKey("AgenteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestioneTurniAgenti.Server.Entities.Evento", "Evento")
                        .WithMany()
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agente");

                    b.Navigation("Evento");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GestioneTurniAgenti.Server.Entities.Reparto", b =>
                {
                    b.Navigation("Agenti");
                });
#pragma warning restore 612, 618
        }
    }
}
