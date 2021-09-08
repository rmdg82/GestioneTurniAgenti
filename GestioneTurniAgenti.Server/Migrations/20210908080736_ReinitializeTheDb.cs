using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestioneTurniAgenti.Server.Migrations
{
    public partial class ReinitializeTheDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Eventi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Inizio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Fine = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: true),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: true)
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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    UpdatedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: true),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: true)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cb5e5f39-cd6b-4a7c-ba43-c132ed10902c", "9637cfc7-c078-4e01-a198-3ecc7b5cbdb4", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "30f56dc1-007b-4bad-9e9c-8be1d8bc2a5f", "32d15f30-a654-4364-93ee-25aa36d14892", "Super-Admin", "SUPER-ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c4c1cfa4-b89a-47cc-9455-ece920e4fbec", 0, "0d0b2238-4863-4d86-ac89-ca52983f220f", null, false, false, null, null, "123456AB", "AQAAAAEAACcQAAAAEBhCzSjp9Xitqv6LXPb2I01Y0LfEv+ZTqsk2Widllwynhg5Qi8ZU3cDdymz/h+TO6Q==", null, false, "9b5f1901-7323-460d-82ea-a68b9a149a55", false, "123456AB" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3c1088ae-a59e-4b17-8754-48cf84b420c6", 0, "23187f43-9ef7-41df-9292-a79d9e4e05fc", null, false, false, null, null, "789012CD", "AQAAAAEAACcQAAAAEGf1TDH+2froD1Ik9pGoCRX8feTVHfRH5YopiQ3p7fhb+vLHgCi2PBLiHreTHhAaMA==", null, false, "da55d106-8bad-48e6-aa75-817c48fa09f4", false, "789012CD" });

            migrationBuilder.InsertData(
                table: "Eventi",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Fine", "Inizio", "Nome", "UpdatedBy", "UpdatedOn" },
                values: new object[] { new Guid("95146179-3589-4a7a-916e-0d696574273e"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Evento1", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Eventi",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Fine", "Inizio", "Nome", "UpdatedBy", "UpdatedOn" },
                values: new object[] { new Guid("0adc2d1c-7f8d-41a7-8a70-ac0b498ba4f9"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Evento2", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

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
                values: new object[] { new Guid("1d510fbc-9a24-4a60-810b-e8513851b1a1"), "Verdi", "135267EF", "Pietro", new Guid("144913db-12eb-4751-ab94-be4b26b777e1") });

            migrationBuilder.InsertData(
                table: "Agenti",
                columns: new[] { "Id", "Cognome", "Matricola", "Nome", "RepartoId" },
                values: new object[] { new Guid("50dc6495-494c-4262-8933-caf914bea25e"), "Giallo", "123432HG", "Guido", new Guid("144913db-12eb-4751-ab94-be4b26b777e1") });

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
                values: new object[] { new Guid("c4c1cfa4-b89a-47cc-9455-ece920e4fbec"), "Rossi", "123456AB", "Mario", new Guid("7f2fb853-4aab-43d3-9448-d9f3edbc793c") });

            migrationBuilder.InsertData(
                table: "Agenti",
                columns: new[] { "Id", "Cognome", "Matricola", "Nome", "RepartoId" },
                values: new object[] { new Guid("3c1088ae-a59e-4b17-8754-48cf84b420c6"), "Bianchi", "789012CD", "Antonio", new Guid("7f2fb853-4aab-43d3-9448-d9f3edbc793c") });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "cb5e5f39-cd6b-4a7c-ba43-c132ed10902c", "c4c1cfa4-b89a-47cc-9455-ece920e4fbec" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "30f56dc1-007b-4bad-9e9c-8be1d8bc2a5f", "3c1088ae-a59e-4b17-8754-48cf84b420c6" });

            migrationBuilder.CreateIndex(
                name: "IX_Agenti_Matricola",
                table: "Agenti",
                column: "Matricola",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Agenti_RepartoId",
                table: "Agenti",
                column: "RepartoId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Eventi_Nome",
                table: "Eventi",
                column: "Nome",
                unique: true);

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Turni");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Agenti");

            migrationBuilder.DropTable(
                name: "Eventi");

            migrationBuilder.DropTable(
                name: "Reparti");
        }
    }
}
