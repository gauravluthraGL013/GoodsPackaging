using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace GoodsPackaging.Data.Migrations
{
    public partial class inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    CompanyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "GoodsType",
                columns: table => new
                {
                    GoodsTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GoodType = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodsType", x => x.GoodsTypeId);
                });

            migrationBuilder.CreateTable(
                name: "PackageType",
                columns: table => new
                {
                    PackageTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PackagingType = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageType", x => x.PackageTypeId);
                });

            migrationBuilder.CreateTable(
                name: "CompanyGoodsPackage",
                columns: table => new
                {
                    companyGoodsPackageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(nullable: false),
                    PackageTypeid = table.Column<int>(nullable: false),
                    GoodsTypeId = table.Column<int>(nullable: false),
                    PackagingDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyGoodsPackage", x => x.companyGoodsPackageId);
                    table.ForeignKey(
                        name: "FK_CompanyGoodsPackage_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyGoodsPackage_GoodsType_GoodsTypeId",
                        column: x => x.GoodsTypeId,
                        principalTable: "GoodsType",
                        principalColumn: "GoodsTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyGoodsPackage_PackageType_PackageTypeid",
                        column: x => x.PackageTypeid,
                        principalTable: "PackageType",
                        principalColumn: "PackageTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyGoodsPackage_CompanyId",
                table: "CompanyGoodsPackage",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyGoodsPackage_GoodsTypeId",
                table: "CompanyGoodsPackage",
                column: "GoodsTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyGoodsPackage_PackageTypeid",
                table: "CompanyGoodsPackage",
                column: "PackageTypeid");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyGoodsPackage");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "GoodsType");

            migrationBuilder.DropTable(
                name: "PackageType");
        }
    }
}
