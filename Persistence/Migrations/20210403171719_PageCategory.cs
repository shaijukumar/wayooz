using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class PageCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PageCategorys",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Pid = table.Column<Guid>(type: "TEXT", nullable: false),
                    Prop1 = table.Column<string>(type: "TEXT", nullable: true),
                    Prop2 = table.Column<string>(type: "TEXT", nullable: true),
                    Prop3 = table.Column<string>(type: "TEXT", nullable: true),
                    Prop4 = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageCategorys", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PageCategorys");
        }
    }
}
