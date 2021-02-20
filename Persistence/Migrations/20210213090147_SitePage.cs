using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class SitePage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SitePageId",
                table: "PageTags",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SitePages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    URLTitle = table.Column<string>(type: "TEXT", nullable: true),
                    PageHtml = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SitePages", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PageTags_SitePages_SitePageId",
                table: "PageTags");

            migrationBuilder.DropTable(
                name: "SitePages");

            migrationBuilder.DropIndex(
                name: "IX_PageTags_SitePageId",
                table: "PageTags");

            migrationBuilder.DropColumn(
                name: "SitePageId",
                table: "PageTags");
        }
    }
}
