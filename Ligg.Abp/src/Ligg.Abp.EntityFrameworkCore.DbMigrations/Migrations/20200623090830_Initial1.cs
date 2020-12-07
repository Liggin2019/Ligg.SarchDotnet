using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ligg.Abp.EntityFrameworkCore.DbMigrations.Migrations
{
    public partial class Initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adm.Transactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 24, nullable: true),
                    ParentName = table.Column<string>(maxLength: 24, nullable: true),
                    Type = table.Column<int>(nullable: false),
                    DisplayName = table.Column<string>(maxLength: 64, nullable: true),
                    Url = table.Column<string>(maxLength: 64, nullable: true),
                    ImageKey = table.Column<int>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    ModificationTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adm.Transactions", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adm.Transactions");
        }
    }
}
