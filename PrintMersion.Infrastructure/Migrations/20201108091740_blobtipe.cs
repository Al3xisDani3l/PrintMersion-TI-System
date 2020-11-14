using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PrintMersion.Infrastructure.Migrations
{
    public partial class blobtipe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "DataRaw",
                table: "Pictures",
                type: "LONGBLOB",
                unicode: false,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldUnicode: false,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DataRaw",
                table: "Pictures",
                type: "text",
                unicode: false,
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "LONGBLOB",
                oldUnicode: false,
                oldNullable: true);
        }
    }
}
