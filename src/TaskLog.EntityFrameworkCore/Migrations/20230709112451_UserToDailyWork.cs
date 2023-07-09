using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskLog.Migrations
{
    public partial class UserToDailyWork : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "DailyWorks",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_DailyWorks_UserId",
                table: "DailyWorks",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_DailyWorks_AbpUsers_UserId",
                table: "DailyWorks",
                column: "UserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyWorks_AbpUsers_UserId",
                table: "DailyWorks");

            migrationBuilder.DropIndex(
                name: "IX_DailyWorks_UserId",
                table: "DailyWorks");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "DailyWorks");
        }
    }
}
