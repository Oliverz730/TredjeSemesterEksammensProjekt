using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TredjeSemesterEksamensProjekt.SqlServerContext.Migrations.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ansat");

            migrationBuilder.EnsureSchema(
                name: "kompetance");

            migrationBuilder.EnsureSchema(
                name: "opgave");

            migrationBuilder.CreateTable(
                name: "Ansat",
                schema: "ansat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ansat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kompetance",
                schema: "kompetance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kompetance", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnsatEntityKompetanceEntity",
                columns: table => new
                {
                    AnsatteId = table.Column<int>(type: "int", nullable: false),
                    KompetancerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnsatEntityKompetanceEntity", x => new { x.AnsatteId, x.KompetancerId });
                    table.ForeignKey(
                        name: "FK_AnsatEntityKompetanceEntity_Ansat_AnsatteId",
                        column: x => x.AnsatteId,
                        principalSchema: "ansat",
                        principalTable: "Ansat",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnsatEntityKompetanceEntity_Kompetance_KompetancerId",
                        column: x => x.KompetancerId,
                        principalSchema: "kompetance",
                        principalTable: "Kompetance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Opgave",
                schema: "opgave",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KompetanceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opgave", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Opgave_Kompetance_KompetanceId",
                        column: x => x.KompetanceId,
                        principalSchema: "kompetance",
                        principalTable: "Kompetance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnsatEntityKompetanceEntity_KompetancerId",
                table: "AnsatEntityKompetanceEntity",
                column: "KompetancerId");

            migrationBuilder.CreateIndex(
                name: "IX_Opgave_KompetanceId",
                schema: "opgave",
                table: "Opgave",
                column: "KompetanceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnsatEntityKompetanceEntity");

            migrationBuilder.DropTable(
                name: "Opgave",
                schema: "opgave");

            migrationBuilder.DropTable(
                name: "Ansat",
                schema: "ansat");

            migrationBuilder.DropTable(
                name: "Kompetance",
                schema: "kompetance");
        }
    }
}
