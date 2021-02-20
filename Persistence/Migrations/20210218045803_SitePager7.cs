using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class SitePager7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PageTagSitePage");

            migrationBuilder.AddColumn<string>(
                name: "Tags",
                table: "SitePages",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tags",
                table: "SitePages");

            migrationBuilder.CreateTable(
                name: "PageTagSitePage",
                columns: table => new
                {
                    PageTagId = table.Column<Guid>(type: "TEXT", nullable: false),
                    SitePageId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageTagSitePage", x => new { x.PageTagId, x.SitePageId });
                    table.ForeignKey(
                        name: "FK_PageTagSitePage_PageTags_PageTagId",
                        column: x => x.PageTagId,
                        principalTable: "PageTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PageTagSitePage_SitePages_SitePageId",
                        column: x => x.SitePageId,
                        principalTable: "SitePages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PageTagSitePage_SitePageId",
                table: "PageTagSitePage",
                column: "SitePageId");
        }
    }
}
