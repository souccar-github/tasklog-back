using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskLog.Migrations
{
    public partial class RichTextEditor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RichTextDescription",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RichTextDescription",
                table: "Tasks");
        }
    }
}
