using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class SitePager : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PageTags_SitePages_SitePageId",
                table: "PageTags");

            migrationBuilder.DropIndex(
                name: "IX_PageTags_SitePageId",
                table: "PageTags");

            migrationBuilder.DropColumn(
                name: "SitePageId",
                table: "PageTags");

            migrationBuilder.CreateTable(
                name: "PageTagSitePage",
                columns: table => new
                {
                    SitePagesId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TagsId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageTagSitePage", x => new { x.SitePagesId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_PageTagSitePage_PageTags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "PageTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PageTagSitePage_SitePages_SitePagesId",
                        column: x => x.SitePagesId,
                        principalTable: "SitePages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PageTagSitePage_TagsId",
                table: "PageTagSitePage",
                column: "TagsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PageTagSitePage");

            migrationBuilder.AddColumn<Guid>(
                name: "SitePageId",
                table: "PageTags",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PageTags_SitePageId",
                table: "PageTags",
                column: "SitePageId");

            migrationBuilder.AddForeignKey(
                name: "FK_PageTags_SitePages_SitePageId",
                table: "PageTags",
                column: "SitePageId",
                principalTable: "SitePages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
