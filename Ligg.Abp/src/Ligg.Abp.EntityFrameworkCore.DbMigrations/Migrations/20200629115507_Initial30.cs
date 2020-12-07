using Microsoft.EntityFrameworkCore.Migrations;

namespace Ligg.Abp.EntityFrameworkCore.DbMigrations.Migrations
{
    public partial class Initial30 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Builtin",
                table: "Adm.Users",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Builtin",
                table: "Adm.Users");
        }
    }
}
