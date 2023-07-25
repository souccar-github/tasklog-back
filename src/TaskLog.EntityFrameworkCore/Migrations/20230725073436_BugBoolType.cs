using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskLog.Migrations
{
    public partial class BugBoolType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isBug",
                table: "Tasks",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isBug",
                table: "Tasks");
        }
    }
}
