using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestioneTurniAgenti.Server.Migrations
{
    public partial class InitialDatabaseScheme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Eventi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Inizio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Fine = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventi", x => x.Id);
                    table.CheckConstraint("CK_Eventi_InizioPrecedenteFine", "Inizio <= Fine");
                });

            migrationBuilder.CreateTable(
                name: "Reparti",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reparti", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Agenti",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Matricola = table.Column<string>(type: "TEXT", fixedLength: true, maxLength: 8, nullable: false),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    Cognome = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    RepartoId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agenti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agenti_Reparti_RepartoId",
                        column: x => x.RepartoId,
                        principalTable: "Reparti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Turni",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    AgenteId = table.Column<Guid>(type: "TEXT", nullable: false),
                    EventoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Data = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Note = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turni", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Turni_Agenti_AgenteId",
                        column: x => x.AgenteId,
                        principalTable: "Agenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Turni_Eventi_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Eventi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agenti_RepartoId",
                table: "Agenti",
                column: "RepartoId");

            migrationBuilder.CreateIndex(
                name: "IX_Turni_AgenteId",
                table: "Turni",
                column: "AgenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Turni_EventoId",
                table: "Turni",
                column: "EventoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Turni");

            migrationBuilder.DropTable(
                name: "Agenti");

            migrationBuilder.DropTable(
                name: "Eventi");

            migrationBuilder.DropTable(
                name: "Reparti");
        }
    }
}
