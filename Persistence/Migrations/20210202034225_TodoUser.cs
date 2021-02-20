using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class TodoUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MyPropertyId",
                table: "Todos",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Todos_MyPropertyId",
                table: "Todos",
                column: "MyPropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Todos_AspNetUsers_MyPropertyId",
                table: "Todos",
                column: "MyPropertyId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todos_AspNetUsers_MyPropertyId",
                table: "Todos");

            migrationBuilder.DropIndex(
                name: "IX_Todos_MyPropertyId",
                table: "Todos");

            migrationBuilder.DropColumn(
                name: "MyPropertyId",
                table: "Todos");
        }
    }
}
