using Microsoft.EntityFrameworkCore.Migrations;

namespace Ligg.Abp.EntityFrameworkCore.DbMigrations.Migrations
{
    public partial class Initial6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Adm.Transactions",
                table: "Adm.Transactions");

            migrationBuilder.RenameTable(
                name: "Adm.Transactions",
                newName: "Cfg.Transactions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cfg.Transactions",
                table: "Cfg.Transactions",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Cfg.Transactions",
                table: "Cfg.Transactions");

            migrationBuilder.RenameTable(
                name: "Cfg.Transactions",
                newName: "Adm.Transactions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Adm.Transactions",
                table: "Adm.Transactions",
                column: "Id");
        }
    }
}
