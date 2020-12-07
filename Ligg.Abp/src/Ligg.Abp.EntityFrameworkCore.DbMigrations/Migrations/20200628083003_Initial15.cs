using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ligg.Abp.EntityFrameworkCore.DbMigrations.Migrations
{
    public partial class Initial15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adm.Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Code = table.Column<string>(maxLength: 24, nullable: false),
                    Name = table.Column<string>(maxLength: 32, nullable: false),
                    Password = table.Column<string>(maxLength: 24, nullable: true),
                    Email = table.Column<string>(maxLength: 20, nullable: true),
                    IsRoot = table.Column<bool>(nullable: false),
                    OrderTag = table.Column<string>(maxLength: 24, nullable: false),
                    Disabled = table.Column<bool>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    ModificationTime = table.Column<DateTime>(nullable: true),
                    ParentCode = table.Column<string>(maxLength: 24, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adm.Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cfg.Organizations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ParentId = table.Column<Guid>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Code = table.Column<string>(maxLength: 24, nullable: false),
                    ShortName = table.Column<string>(maxLength: 32, nullable: true),
                    DisplayName = table.Column<string>(maxLength: 32, nullable: true),
                    OrderTag = table.Column<string>(maxLength: 24, nullable: true),
                    ImageKey = table.Column<int>(nullable: false),
                    Disabled = table.Column<bool>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    ModificationTime = table.Column<DateTime>(nullable: true),
                    ParentCode = table.Column<string>(maxLength: 24, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cfg.Organizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cfg.Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Code = table.Column<string>(maxLength: 24, nullable: true),
                    DisplayName = table.Column<string>(maxLength: 32, nullable: false),
                    Description = table.Column<string>(maxLength: 64, nullable: true),
                    Builtin = table.Column<bool>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    ModificationTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cfg.Roles", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adm.Users");

            migrationBuilder.DropTable(
                name: "Cfg.Organizations");

            migrationBuilder.DropTable(
                name: "Cfg.Roles");
        }
    }
}
