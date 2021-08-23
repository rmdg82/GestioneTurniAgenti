﻿// <auto-generated />
using System;
using GestioneTurniAgenti.Server.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GestioneTurniAgenti.Server.Migrations
{
    [DbContext(typeof(GestioneTurniDbContext))]
    [Migration("20210821170922_SeedDatabase")]
    partial class SeedDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.HasIndex("RepartoId");

                    b.ToTable("Agenti");

                    b.HasData(
                        new
                        {
                            Id = new Guid("51f72889-dd00-47e6-9f2e-caf8c8e537fe"),
                            Cognome = "Rossi",
                            Matricola = "123456AB",
                            Nome = "Mario",
                            RepartoId = new Guid("7f2fb853-4aab-43d3-9448-d9f3edbc793c")
                        },
                        new
                        {
                            Id = new Guid("81307831-087b-4cc0-aebd-5208cd1f7f3c"),
                            Cognome = "Bianchi",
                            Matricola = "789012CD",
                            Nome = "Antonio",
                            RepartoId = new Guid("7f2fb853-4aab-43d3-9448-d9f3edbc793c")
                        },
                        new
                        {
                            Id = new Guid("f9373b83-c588-4f1e-ac87-a62474af2190"),
                            Cognome = "Verdi",
                            Matricola = "135267EF",
                            Nome = "Pietro",
                            RepartoId = new Guid("144913db-12eb-4751-ab94-be4b26b777e1")
                        },
                        new
                        {
                            Id = new Guid("9e440a69-eeda-4f87-8b45-b79490515603"),
                            Cognome = "Blu",
                            Matricola = "564922HJ",
                            Nome = "Antonio",
                            RepartoId = new Guid("7307b34f-052c-4ef1-b0c3-fb6b3ffe8f3f")
                        },
                        new
                        {
                            Id = new Guid("8ac46bbc-0657-4cdb-a1a9-f44a53a7a223"),
                            Cognome = "Viola",
                            Matricola = "789012FG",
                            Nome = "Paolo",
                            RepartoId = new Guid("7307b34f-052c-4ef1-b0c3-fb6b3ffe8f3f")
                        });
                });

            modelBuilder.Entity("GestioneTurniAgenti.Server.Entities.Evento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
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

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

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

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Data")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("EventoId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Note")
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AgenteId");

                    b.HasIndex("EventoId");

                    b.ToTable("Turni");
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

            modelBuilder.Entity("GestioneTurniAgenti.Server.Entities.Reparto", b =>
                {
                    b.Navigation("Agenti");
                });
#pragma warning restore 612, 618
        }
    }
}
