using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TredjeSemesterEksamensProjekt.SqlServerContext.Migrations.Migrations
{
    public partial class RowVersionIgangsættelse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Opgave",
                schema: "opgave");

            migrationBuilder.EnsureSchema(
                name: "opgaveType");

            migrationBuilder.EnsureSchema(
                name: "projekt");

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                schema: "kompetance",
                table: "Kompetance",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                schema: "ansat",
                table: "Ansat",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.CreateTable(
                name: "OpgaveType",
                schema: "opgaveType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Beskrivelse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KompetanceId = table.Column<int>(type: "int", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpgaveType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projekt",
                schema: "projekt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstimatedTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActualEstimated = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SælgerUserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KundeUserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projekt", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OpgaveType",
                schema: "opgaveType");

            migrationBuilder.DropTable(
                name: "Projekt",
                schema: "projekt");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                schema: "kompetance",
                table: "Kompetance");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                schema: "ansat",
                table: "Ansat");

            migrationBuilder.EnsureSchema(
                name: "opgave");

            migrationBuilder.CreateTable(
                name: "Opgave",
                schema: "opgave",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KompetanceId = table.Column<int>(type: "int", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                name: "IX_Opgave_KompetanceId",
                schema: "opgave",
                table: "Opgave",
                column: "KompetanceId");
        }
    }
}
