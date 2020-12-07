using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ligg.Abp.EntityFrameworkCore.DbMigrations.Migrations
{
    public partial class Initial12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Cfg.Transactions");

            migrationBuilder.DropColumn(
                name: "ParentName",
                table: "Cfg.Transactions");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Cfg.Transactions",
                maxLength: 24,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ParentCode",
                table: "Cfg.Transactions",
                maxLength: 24,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "ParentId",
                table: "Cfg.Transactions",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Cfg.Transactions");

            migrationBuilder.DropColumn(
                name: "ParentCode",
                table: "Cfg.Transactions");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Cfg.Transactions");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Cfg.Transactions",
                type: "nvarchar(24)",
                maxLength: 24,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ParentName",
                table: "Cfg.Transactions",
                type: "nvarchar(24)",
                maxLength: 24,
                nullable: false,
                defaultValue: "");
        }
    }
}
