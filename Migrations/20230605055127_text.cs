﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineDiary.Migrations
{
    public partial class text : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Entry",
                table: "MyDiary",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Entry",
                table: "MyDiary",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
