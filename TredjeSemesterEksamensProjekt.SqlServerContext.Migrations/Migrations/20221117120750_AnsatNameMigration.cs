using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TredjeSemesterEksamensProjekt.SqlServerContext.Migrations.Migrations
{
    public partial class AnsatNameMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "ansat",
                table: "Ansat",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                schema: "ansat",
                table: "Ansat");
        }
    }
}
