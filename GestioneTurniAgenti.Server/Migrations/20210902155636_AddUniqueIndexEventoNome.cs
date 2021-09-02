using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestioneTurniAgenti.Server.Migrations
{
    public partial class AddUniqueIndexEventoNome : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                values: new object[] { new Guid("0f1be614-2e19-423d-8a81-13730671fb30"), "Rossi", "123456AB", "Mario", new Guid("7f2fb853-4aab-43d3-9448-d9f3edbc793c") });

            migrationBuilder.InsertData(
                table: "Agenti",
                columns: new[] { "Id", "Cognome", "Matricola", "Nome", "RepartoId" },
                values: new object[] { new Guid("d4661dd3-0d12-48c2-ae77-0fac08abc1d2"), "Bianchi", "789012CD", "Antonio", new Guid("7f2fb853-4aab-43d3-9448-d9f3edbc793c") });

            migrationBuilder.InsertData(
                table: "Agenti",
                columns: new[] { "Id", "Cognome", "Matricola", "Nome", "RepartoId" },
                values: new object[] { new Guid("7d0576d2-f508-479b-a812-33dbe4d18f2b"), "Verdi", "135267EF", "Pietro", new Guid("144913db-12eb-4751-ab94-be4b26b777e1") });

            migrationBuilder.InsertData(
                table: "Agenti",
                columns: new[] { "Id", "Cognome", "Matricola", "Nome", "RepartoId" },
                values: new object[] { new Guid("ff0072cb-1958-436c-b683-81723ba8433b"), "Blu", "564922HJ", "Antonio", new Guid("7307b34f-052c-4ef1-b0c3-fb6b3ffe8f3f") });

            migrationBuilder.InsertData(
                table: "Agenti",
                columns: new[] { "Id", "Cognome", "Matricola", "Nome", "RepartoId" },
                values: new object[] { new Guid("b49edd94-8d72-42b9-bb9d-b13bcc69120e"), "Viola", "789012FG", "Paolo", new Guid("7307b34f-052c-4ef1-b0c3-fb6b3ffe8f3f") });

            migrationBuilder.InsertData(
                table: "Agenti",
                columns: new[] { "Id", "Cognome", "Matricola", "Nome", "RepartoId" },
                values: new object[] { new Guid("f8e018f7-b474-40d9-a861-0437397b2fa5"), "Giallo", "123432HG", "Guido", new Guid("144913db-12eb-4751-ab94-be4b26b777e1") });

            migrationBuilder.CreateIndex(
                name: "IX_Eventi_Nome",
                table: "Eventi",
                column: "Nome",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Eventi_Nome",
                table: "Eventi");

            migrationBuilder.DeleteData(
                table: "Agenti",
                keyColumn: "Id",
                keyValue: new Guid("0f1be614-2e19-423d-8a81-13730671fb30"));

            migrationBuilder.DeleteData(
                table: "Agenti",
                keyColumn: "Id",
                keyValue: new Guid("7d0576d2-f508-479b-a812-33dbe4d18f2b"));

            migrationBuilder.DeleteData(
                table: "Agenti",
                keyColumn: "Id",
                keyValue: new Guid("b49edd94-8d72-42b9-bb9d-b13bcc69120e"));

            migrationBuilder.DeleteData(
                table: "Agenti",
                keyColumn: "Id",
                keyValue: new Guid("d4661dd3-0d12-48c2-ae77-0fac08abc1d2"));

            migrationBuilder.DeleteData(
                table: "Agenti",
                keyColumn: "Id",
                keyValue: new Guid("f8e018f7-b474-40d9-a861-0437397b2fa5"));

            migrationBuilder.DeleteData(
                table: "Agenti",
                keyColumn: "Id",
                keyValue: new Guid("ff0072cb-1958-436c-b683-81723ba8433b"));

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
        }
    }
}
