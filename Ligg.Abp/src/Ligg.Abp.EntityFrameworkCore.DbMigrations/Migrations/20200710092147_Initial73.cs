using Microsoft.EntityFrameworkCore.Migrations;

namespace Ligg.Abp.EntityFrameworkCore.DbMigrations.Migrations
{
    public partial class Initial73 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Builtin",
                table: "Cfg.Roles");

            migrationBuilder.AddColumn<string>(
                name: "OrderTag",
                table: "Cfg.Roles",
                maxLength: 16,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderTag",
                table: "Cfg.Roles");

            migrationBuilder.AddColumn<bool>(
                name: "Builtin",
                table: "Cfg.Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
