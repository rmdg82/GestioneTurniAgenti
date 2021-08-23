using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestioneTurniAgenti.Server.Migrations
{
    public partial class AddUniqueIndexAgentiMatricola : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Agenti",
                columns: new[] { "Id", "Cognome", "Matricola", "Nome", "RepartoId" },
                values: new object[] { new Guid("c6f798ed-211e-4c5e-8855-c7512bc66839"), "Rossi", "123456AB", "Mario", new Guid("7f2fb853-4aab-43d3-9448-d9f3edbc793c") });

            migrationBuilder.InsertData(
                table: "Agenti",
                columns: new[] { "Id", "Cognome", "Matricola", "Nome", "RepartoId" },
                values: new object[] { new Guid("c4a4a55e-8d1a-4f05-8312-61b884a7fb38"), "Bianchi", "789012CD", "Antonio", new Guid("7f2fb853-4aab-43d3-9448-d9f3edbc793c") });

            migrationBuilder.InsertData(
                table: "Agenti",
                columns: new[] { "Id", "Cognome", "Matricola", "Nome", "RepartoId" },
                values: new object[] { new Guid("82b11398-e693-496a-862b-9e3a32988aa0"), "Verdi", "135267EF", "Pietro", new Guid("144913db-12eb-4751-ab94-be4b26b777e1") });

            migrationBuilder.InsertData(
                table: "Agenti",
                columns: new[] { "Id", "Cognome", "Matricola", "Nome", "RepartoId" },
                values: new object[] { new Guid("ca0d2a00-fdf1-4117-872b-19f537c59d39"), "Blu", "564922HJ", "Antonio", new Guid("7307b34f-052c-4ef1-b0c3-fb6b3ffe8f3f") });

            migrationBuilder.InsertData(
                table: "Agenti",
                columns: new[] { "Id", "Cognome", "Matricola", "Nome", "RepartoId" },
                values: new object[] { new Guid("5e1a47a0-af23-4de8-b773-75ab5db73e9c"), "Viola", "789012FG", "Paolo", new Guid("7307b34f-052c-4ef1-b0c3-fb6b3ffe8f3f") });

            migrationBuilder.CreateIndex(
                name: "IX_Agenti_Matricola",
                table: "Agenti",
                column: "Matricola",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Agenti_Matricola",
                table: "Agenti");

            migrationBuilder.DeleteData(
                table: "Agenti",
                keyColumn: "Id",
                keyValue: new Guid("5e1a47a0-af23-4de8-b773-75ab5db73e9c"));

            migrationBuilder.DeleteData(
                table: "Agenti",
                keyColumn: "Id",
                keyValue: new Guid("82b11398-e693-496a-862b-9e3a32988aa0"));

            migrationBuilder.DeleteData(
                table: "Agenti",
                keyColumn: "Id",
                keyValue: new Guid("c4a4a55e-8d1a-4f05-8312-61b884a7fb38"));

            migrationBuilder.DeleteData(
                table: "Agenti",
                keyColumn: "Id",
                keyValue: new Guid("c6f798ed-211e-4c5e-8855-c7512bc66839"));

            migrationBuilder.DeleteData(
                table: "Agenti",
                keyColumn: "Id",
                keyValue: new Guid("ca0d2a00-fdf1-4117-872b-19f537c59d39"));

            migrationBuilder.InsertData(
                table: "Agenti",
                columns: new[] { "Id", "Cognome", "Matricola", "Nome", "RepartoId" },
                values: new object[] { new Guid("51f72889-dd00-47e6-9f2e-caf8c8e537fe"), "Rossi", "123456AB", "Mario", new Guid("7f2fb853-4aab-43d3-9448-d9f3edbc793c") });

            migrationBuilder.InsertData(
                table: "Agenti",
                columns: new[] { "Id", "Cognome", "Matricola", "Nome", "RepartoId" },
                values: new object[] { new Guid("81307831-087b-4cc0-aebd-5208cd1f7f3c"), "Bianchi", "789012CD", "Antonio", new Guid("7f2fb853-4aab-43d3-9448-d9f3edbc793c") });

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
        }
    }
}
