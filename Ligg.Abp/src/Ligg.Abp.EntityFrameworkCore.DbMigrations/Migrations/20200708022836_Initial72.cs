using Microsoft.EntityFrameworkCore.Migrations;

namespace Ligg.Abp.EntityFrameworkCore.DbMigrations.Migrations
{
    public partial class Initial72 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentCode",
                table: "Cfg.Transactions");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Cfg.Transactions");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Cfg.Transactions",
                maxLength: 64,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Cfg.Transactions");

            migrationBuilder.AddColumn<string>(
                name: "ParentCode",
                table: "Cfg.Transactions",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Cfg.Transactions",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true);
        }
    }
}
