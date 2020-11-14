using Microsoft.EntityFrameworkCore.Migrations;

namespace PrintMersion.Infrastructure.Migrations
{
    public partial class SetImageUserRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdPicture",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdPicture",
                table: "Users",
                column: "IdPicture");

            migrationBuilder.AddForeignKey(
                name: "fk_User_Picture",
                table: "Users",
                column: "IdPicture",
                principalTable: "Pictures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_User_Picture",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_IdPicture",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IdPicture",
                table: "Users");
        }
    }
}
