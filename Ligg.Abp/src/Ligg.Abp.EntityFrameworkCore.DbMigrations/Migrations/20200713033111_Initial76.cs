using Microsoft.EntityFrameworkCore.Migrations;

namespace Ligg.Abp.EntityFrameworkCore.DbMigrations.Migrations
{
    public partial class Initial76 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Cfg.MaterialUnits",
                table: "Cfg.MaterialUnits");

            migrationBuilder.RenameTable(
                name: "Cfg.MaterialUnits",
                newName: "Biz.MaterialUnits");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Biz.MaterialUnits",
                table: "Biz.MaterialUnits",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Biz.MaterialUnits",
                table: "Biz.MaterialUnits");

            migrationBuilder.RenameTable(
                name: "Biz.MaterialUnits",
                newName: "Cfg.MaterialUnits");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cfg.MaterialUnits",
                table: "Cfg.MaterialUnits",
                column: "Id");
        }
    }
}
