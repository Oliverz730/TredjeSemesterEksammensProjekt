using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TredjeSemesterEksamensProjekt.SqlServerContext.Migrations.Migrations
{
    public partial class NullableProjekt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "EstimatedTime",
                schema: "projekt",
                table: "Projekt",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                schema: "projekt",
                table: "Projekt",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "ActualEstimated",
                schema: "projekt",
                table: "Projekt",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "MedarbejderId",
                schema: "booking",
                table: "Booking",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MedarbejderId",
                schema: "booking",
                table: "Booking");

            migrationBuilder.AlterColumn<string>(
                name: "EstimatedTime",
                schema: "projekt",
                table: "Projekt",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                schema: "projekt",
                table: "Projekt",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ActualEstimated",
                schema: "projekt",
                table: "Projekt",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
