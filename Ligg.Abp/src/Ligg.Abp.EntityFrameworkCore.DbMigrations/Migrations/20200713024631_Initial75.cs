using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ligg.Abp.EntityFrameworkCore.DbMigrations.Migrations
{
    public partial class Initial75 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Biz.Materials",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    No = table.Column<long>(nullable: false),
                    NameId = table.Column<Guid>(nullable: false),
                    Specification = table.Column<string>(maxLength: 64, nullable: true),
                    OtherAttribute = table.Column<string>(maxLength: 64, nullable: true),
                    Stuff = table.Column<string>(maxLength: 64, nullable: true),
                    DrawingCode = table.Column<string>(maxLength: 64, nullable: true),
                    BasicUnitId = table.Column<Guid>(nullable: false),
                    Disabled = table.Column<bool>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    LastModifierId = table.Column<Guid>(nullable: false),
                    ModificationTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biz.Materials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cfg.MaterialCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ParentId = table.Column<Guid>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    No = table.Column<long>(nullable: false),
                    DisplayName = table.Column<string>(maxLength: 32, nullable: false),
                    CreatorId = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    LastModifierId = table.Column<Guid>(nullable: false),
                    ModificationTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cfg.MaterialCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cfg.MaterialUnits",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UnitId = table.Column<Guid>(nullable: false),
                    BasicUnitId = table.Column<Guid>(nullable: false),
                    Coefficient = table.Column<float>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    LastModifierId = table.Column<Guid>(nullable: false),
                    ModificationTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cfg.MaterialUnits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cfg.Units",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Code = table.Column<string>(maxLength: 16, nullable: true),
                    DisplayName = table.Column<string>(maxLength: 32, nullable: false),
                    Description = table.Column<string>(maxLength: 64, nullable: true),
                    IsBasicUnit = table.Column<bool>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    LastModifierId = table.Column<Guid>(nullable: false),
                    ModificationTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cfg.Units", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Biz.Materials");

            migrationBuilder.DropTable(
                name: "Cfg.MaterialCategories");

            migrationBuilder.DropTable(
                name: "Cfg.MaterialUnits");

            migrationBuilder.DropTable(
                name: "Cfg.Units");
        }
    }
}
