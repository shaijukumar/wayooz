using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class SitePager3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PageTagSitePage_PageTags_TagsId",
                table: "PageTagSitePage");

            migrationBuilder.DropForeignKey(
                name: "FK_PageTagSitePage_SitePages_SitePagesId",
                table: "PageTagSitePage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PageTagSitePage",
                table: "PageTagSitePage");

            migrationBuilder.RenameTable(
                name: "PageTagSitePage",
                newName: "PostTags");

            migrationBuilder.RenameIndex(
                name: "IX_PageTagSitePage_TagsId",
                table: "PostTags",
                newName: "IX_PostTags_TagsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostTags",
                table: "PostTags",
                columns: new[] { "SitePagesId", "TagsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PostTags_PageTags_TagsId",
                table: "PostTags",
                column: "TagsId",
                principalTable: "PageTags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostTags_SitePages_SitePagesId",
                table: "PostTags",
                column: "SitePagesId",
                principalTable: "SitePages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostTags_PageTags_TagsId",
                table: "PostTags");

            migrationBuilder.DropForeignKey(
                name: "FK_PostTags_SitePages_SitePagesId",
                table: "PostTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostTags",
                table: "PostTags");

            migrationBuilder.RenameTable(
                name: "PostTags",
                newName: "PageTagSitePage");

            migrationBuilder.RenameIndex(
                name: "IX_PostTags_TagsId",
                table: "PageTagSitePage",
                newName: "IX_PageTagSitePage_TagsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PageTagSitePage",
                table: "PageTagSitePage",
                columns: new[] { "SitePagesId", "TagsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PageTagSitePage_PageTags_TagsId",
                table: "PageTagSitePage",
                column: "TagsId",
                principalTable: "PageTags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PageTagSitePage_SitePages_SitePagesId",
                table: "PageTagSitePage",
                column: "SitePagesId",
                principalTable: "SitePages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
