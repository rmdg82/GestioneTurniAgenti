using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestioneTurniAgenti.Server.Migrations
{
    public partial class SeedIdentityData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Agenti",
                keyColumn: "Id",
                keyValue: new Guid("02ba7d6d-a4bf-4144-99f9-cac84ed29790"));

            migrationBuilder.DeleteData(
                table: "Agenti",
                keyColumn: "Id",
                keyValue: new Guid("39c654db-da8d-4f7d-911a-a9e857a77ea7"));

            migrationBuilder.DeleteData(
                table: "Agenti",
                keyColumn: "Id",
                keyValue: new Guid("40a34a84-412e-4c53-8dfe-db739bd01202"));

            migrationBuilder.DeleteData(
                table: "Agenti",
                keyColumn: "Id",
                keyValue: new Guid("43bf846b-32d4-4484-a1e9-be79177a23ba"));

            migrationBuilder.DeleteData(
                table: "Agenti",
                keyColumn: "Id",
                keyValue: new Guid("4e051e63-f614-4c2a-9e93-2eeaa5a3c9db"));

            migrationBuilder.DeleteData(
                table: "Agenti",
                keyColumn: "Id",
                keyValue: new Guid("c74e7f28-6216-48bf-8683-5cadc92ddf67"));

            migrationBuilder.InsertData(
                table: "Agenti",
                columns: new[] { "Id", "Cognome", "Matricola", "Nome", "RepartoId" },
                values: new object[] { new Guid("c4c1cfa4-b89a-47cc-9455-ece920e4fbec"), "Rossi", "123456AB", "Mario", new Guid("7f2fb853-4aab-43d3-9448-d9f3edbc793c") });

            migrationBuilder.InsertData(
                table: "Agenti",
                columns: new[] { "Id", "Cognome", "Matricola", "Nome", "RepartoId" },
                values: new object[] { new Guid("3c1088ae-a59e-4b17-8754-48cf84b420c6"), "Bianchi", "789012CD", "Antonio", new Guid("7f2fb853-4aab-43d3-9448-d9f3edbc793c") });

            migrationBuilder.InsertData(
                table: "Agenti",
                columns: new[] { "Id", "Cognome", "Matricola", "Nome", "RepartoId" },
                values: new object[] { new Guid("1d510fbc-9a24-4a60-810b-e8513851b1a1"), "Verdi", "135267EF", "Pietro", new Guid("144913db-12eb-4751-ab94-be4b26b777e1") });

            migrationBuilder.InsertData(
                table: "Agenti",
                columns: new[] { "Id", "Cognome", "Matricola", "Nome", "RepartoId" },
                values: new object[] { new Guid("a77588e1-2416-4aa1-bbb9-3182c344a6ad"), "Blu", "564922HJ", "Antonio", new Guid("7307b34f-052c-4ef1-b0c3-fb6b3ffe8f3f") });

            migrationBuilder.InsertData(
                table: "Agenti",
                columns: new[] { "Id", "Cognome", "Matricola", "Nome", "RepartoId" },
                values: new object[] { new Guid("2ee6d35d-551e-486f-956a-998bc23dd24c"), "Viola", "789012FG", "Paolo", new Guid("7307b34f-052c-4ef1-b0c3-fb6b3ffe8f3f") });

            migrationBuilder.InsertData(
                table: "Agenti",
                columns: new[] { "Id", "Cognome", "Matricola", "Nome", "RepartoId" },
                values: new object[] { new Guid("50dc6495-494c-4262-8933-caf914bea25e"), "Giallo", "123432HG", "Guido", new Guid("144913db-12eb-4751-ab94-be4b26b777e1") });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cb5e5f39-cd6b-4a7c-ba43-c132ed10902c", "fe5ab6bc-6a4b-46d8-88ef-498196c3195d", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "30f56dc1-007b-4bad-9e9c-8be1d8bc2a5f", "78360f14-2957-4c7c-a9f4-c89ecd1ab894", "Super-Admin", "SUPER-ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c4c1cfa4-b89a-47cc-9455-ece920e4fbec", 0, "d6434dcb-b833-4613-947f-7573c62f21d6", null, false, false, null, null, "123456AB", "AQAAAAEAACcQAAAAEOpWTr/ydmC85EK/MQ51G0+yW0V7Vx8kaoV6U46Qsn3XkQ1BN11xt+P/H/Ct49N0lA==", null, false, "d5e001d2-92ea-4f42-9278-276d451075cb", false, "123456AB" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3c1088ae-a59e-4b17-8754-48cf84b420c6", 0, "bedc374d-e67c-4960-8e89-b91537865c1c", null, false, false, null, null, "789012CD", "AQAAAAEAACcQAAAAEHQoxGmzOesfcLb7HANWiKDFpnEJOas/jGC6qJxUIoB2l6RUL1k+3B1PX/wFNO2PaQ==", null, false, "cc268f10-da37-4b8d-b996-de72d22bff0b", false, "789012CD" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "cb5e5f39-cd6b-4a7c-ba43-c132ed10902c", "c4c1cfa4-b89a-47cc-9455-ece920e4fbec" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "30f56dc1-007b-4bad-9e9c-8be1d8bc2a5f", "3c1088ae-a59e-4b17-8754-48cf84b420c6" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Agenti",
                keyColumn: "Id",
                keyValue: new Guid("1d510fbc-9a24-4a60-810b-e8513851b1a1"));

            migrationBuilder.DeleteData(
                table: "Agenti",
                keyColumn: "Id",
                keyValue: new Guid("2ee6d35d-551e-486f-956a-998bc23dd24c"));

            migrationBuilder.DeleteData(
                table: "Agenti",
                keyColumn: "Id",
                keyValue: new Guid("3c1088ae-a59e-4b17-8754-48cf84b420c6"));

            migrationBuilder.DeleteData(
                table: "Agenti",
                keyColumn: "Id",
                keyValue: new Guid("50dc6495-494c-4262-8933-caf914bea25e"));

            migrationBuilder.DeleteData(
                table: "Agenti",
                keyColumn: "Id",
                keyValue: new Guid("a77588e1-2416-4aa1-bbb9-3182c344a6ad"));

            migrationBuilder.DeleteData(
                table: "Agenti",
                keyColumn: "Id",
                keyValue: new Guid("c4c1cfa4-b89a-47cc-9455-ece920e4fbec"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "30f56dc1-007b-4bad-9e9c-8be1d8bc2a5f", "3c1088ae-a59e-4b17-8754-48cf84b420c6" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cb5e5f39-cd6b-4a7c-ba43-c132ed10902c", "c4c1cfa4-b89a-47cc-9455-ece920e4fbec" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "30f56dc1-007b-4bad-9e9c-8be1d8bc2a5f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb5e5f39-cd6b-4a7c-ba43-c132ed10902c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3c1088ae-a59e-4b17-8754-48cf84b420c6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c4c1cfa4-b89a-47cc-9455-ece920e4fbec");

            migrationBuilder.InsertData(
                table: "Agenti",
                columns: new[] { "Id", "Cognome", "Matricola", "Nome", "RepartoId" },
                values: new object[] { new Guid("02ba7d6d-a4bf-4144-99f9-cac84ed29790"), "Rossi", "123456AB", "Mario", new Guid("7f2fb853-4aab-43d3-9448-d9f3edbc793c") });

            migrationBuilder.InsertData(
                table: "Agenti",
                columns: new[] { "Id", "Cognome", "Matricola", "Nome", "RepartoId" },
                values: new object[] { new Guid("39c654db-da8d-4f7d-911a-a9e857a77ea7"), "Bianchi", "789012CD", "Antonio", new Guid("7f2fb853-4aab-43d3-9448-d9f3edbc793c") });

            migrationBuilder.InsertData(
                table: "Agenti",
                columns: new[] { "Id", "Cognome", "Matricola", "Nome", "RepartoId" },
                values: new object[] { new Guid("40a34a84-412e-4c53-8dfe-db739bd01202"), "Verdi", "135267EF", "Pietro", new Guid("144913db-12eb-4751-ab94-be4b26b777e1") });

            migrationBuilder.InsertData(
                table: "Agenti",
                columns: new[] { "Id", "Cognome", "Matricola", "Nome", "RepartoId" },
                values: new object[] { new Guid("4e051e63-f614-4c2a-9e93-2eeaa5a3c9db"), "Blu", "564922HJ", "Antonio", new Guid("7307b34f-052c-4ef1-b0c3-fb6b3ffe8f3f") });

            migrationBuilder.InsertData(
                table: "Agenti",
                columns: new[] { "Id", "Cognome", "Matricola", "Nome", "RepartoId" },
                values: new object[] { new Guid("c74e7f28-6216-48bf-8683-5cadc92ddf67"), "Viola", "789012FG", "Paolo", new Guid("7307b34f-052c-4ef1-b0c3-fb6b3ffe8f3f") });

            migrationBuilder.InsertData(
                table: "Agenti",
                columns: new[] { "Id", "Cognome", "Matricola", "Nome", "RepartoId" },
                values: new object[] { new Guid("43bf846b-32d4-4484-a1e9-be79177a23ba"), "Giallo", "123432HG", "Guido", new Guid("144913db-12eb-4751-ab94-be4b26b777e1") });
        }
    }
}
