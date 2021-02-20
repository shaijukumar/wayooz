using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class TodoUser1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todos_AspNetUsers_MyPropertyId",
                table: "Todos");

            migrationBuilder.RenameColumn(
                name: "MyPropertyId",
                table: "Todos",
                newName: "ToDoUSerId");

            migrationBuilder.RenameIndex(
                name: "IX_Todos_MyPropertyId",
                table: "Todos",
                newName: "IX_Todos_ToDoUSerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Todos_AspNetUsers_ToDoUSerId",
                table: "Todos",
                column: "ToDoUSerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todos_AspNetUsers_ToDoUSerId",
                table: "Todos");

            migrationBuilder.RenameColumn(
                name: "ToDoUSerId",
                table: "Todos",
                newName: "MyPropertyId");

            migrationBuilder.RenameIndex(
                name: "IX_Todos_ToDoUSerId",
                table: "Todos",
                newName: "IX_Todos_MyPropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Todos_AspNetUsers_MyPropertyId",
                table: "Todos",
                column: "MyPropertyId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
