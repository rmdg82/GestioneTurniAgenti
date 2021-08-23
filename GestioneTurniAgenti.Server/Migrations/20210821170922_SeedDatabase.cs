using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestioneTurniAgenti.Server.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Eventi",
                columns: new[] { "Id", "CreatedOn", "Fine", "Inizio", "Nome", "UpdatedOn" },
                values: new object[] { new Guid("95146179-3589-4a7a-916e-0d696574273e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Evento1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Eventi",
                columns: new[] { "Id", "CreatedOn", "Fine", "Inizio", "Nome", "UpdatedOn" },
                values: new object[] { new Guid("0adc2d1c-7f8d-41a7-8a70-ac0b498ba4f9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Evento2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Reparti",
                columns: new[] { "Id", "Nome" },
                values: new object[] { new Guid("144913db-12eb-4751-ab94-be4b26b777e1"), "Reparto1" });

            migrationBuilder.InsertData(
                table: "Reparti",
                columns: new[] { "Id", "Nome" },
                values: new object[] { new Guid("7307b34f-052c-4ef1-b0c3-fb6b3ffe8f3f"), "Reparto2" });

            migrationBuilder.InsertData(
                table: "Reparti",
                columns: new[] { "Id", "Nome" },
                values: new object[] { new Guid("7f2fb853-4aab-43d3-9448-d9f3edbc793c"), "Reparto3" });

            migrationBuilder.InsertData(
                table: "Agenti",
                columns: new[] { "Id", "Cognome", "Matricola", "Nome", "RepartoId" },
                values: new object[] { new Guid("f9373b83-c588-4f1e-ac87-a62474af2190"), "Verdi", "135267EF", "Pietro", new Guid("144913db-12eb-4751-ab94-be4b26b777e1") });

            migrationBuilder.InsertData(
                table: "Agenti",
                columns: new[] { "Id", "Cognome", "Matricola", "Nome", "RepartoId" },
                values: new object[] { new Guid("9e440a69-eeda-4f87-8b45-b79490515603"), "Blu", "564922HJ", "Antonio", new Guid("7307b34f-052c-4ef1-b0c3-fb6b3ffe8f3f") });

            migrationBuilder.InsertData(
                table: "Agenti",
                columns: new[] { "Id", "Cognome", "Matricola", "Nome", "RepartoId" },
                values: new object[] { new Guid("8ac46bbc-0657-4cdb-a1a9-f44a53a7a223"), "Viola", "789012FG", "Paolo", new Guid("7307b34f-052c-4ef1-b0c3-fb6b3ffe8f3f") });

            migrationBuilder.InsertData(
                table: "Agenti",
                columns: new[] { "Id", "Cognome", "Matricola", "Nome", "RepartoId" },
                values: new object[] { new Guid("51f72889-dd00-47e6-9f2e-caf8c8e537fe"), "Rossi", "123456AB", "Mario", new Guid("7f2fb853-4aab-43d3-9448-d9f3edbc793c") });

            migrationBuilder.InsertData(
                table: "Agenti",
                columns: new[] { "Id", "Cognome", "Matricola", "Nome", "RepartoId" },
                values: new object[] { new Guid("81307831-087b-4cc0-aebd-5208cd1f7f3c"), "Bianchi", "789012CD", "Antonio", new Guid("7f2fb853-4aab-43d3-9448-d9f3edbc793c") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Agenti",
                keyColumn: "Id",
                keyValue: new Guid("51f72889-dd00-47e6-9f2e-caf8c8e537fe"));

            migrationBuilder.DeleteData(
                table: "Agenti",
                keyColumn: "Id",
                keyValue: new Guid("81307831-087b-4cc0-aebd-5208cd1f7f3c"));

            migrationBuilder.DeleteData(
                table: "Agenti",
                keyColumn: "Id",
                keyValue: new Guid("8ac46bbc-0657-4cdb-a1a9-f44a53a7a223"));

            migrationBuilder.DeleteData(
                table: "Agenti",
                keyColumn: "Id",
                keyValue: new Guid("9e440a69-eeda-4f87-8b45-b79490515603"));

            migrationBuilder.DeleteData(
                table: "Agenti",
                keyColumn: "Id",
                keyValue: new Guid("f9373b83-c588-4f1e-ac87-a62474af2190"));

            migrationBuilder.DeleteData(
                table: "Eventi",
                keyColumn: "Id",
                keyValue: new Guid("0adc2d1c-7f8d-41a7-8a70-ac0b498ba4f9"));

            migrationBuilder.DeleteData(
                table: "Eventi",
                keyColumn: "Id",
                keyValue: new Guid("95146179-3589-4a7a-916e-0d696574273e"));

            migrationBuilder.DeleteData(
                table: "Reparti",
                keyColumn: "Id",
                keyValue: new Guid("144913db-12eb-4751-ab94-be4b26b777e1"));

            migrationBuilder.DeleteData(
                table: "Reparti",
                keyColumn: "Id",
                keyValue: new Guid("7307b34f-052c-4ef1-b0c3-fb6b3ffe8f3f"));

            migrationBuilder.DeleteData(
                table: "Reparti",
                keyColumn: "Id",
                keyValue: new Guid("7f2fb853-4aab-43d3-9448-d9f3edbc793c"));
        }
    }
}
