using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class TodoUser2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todos_AspNetUsers_ToDoUSerId",
                table: "Todos");

            migrationBuilder.RenameColumn(
                name: "ToDoUSerId",
                table: "Todos",
                newName: "ToDoUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Todos_ToDoUSerId",
                table: "Todos",
                newName: "IX_Todos_ToDoUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Todos_AspNetUsers_ToDoUserId",
                table: "Todos",
                column: "ToDoUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todos_AspNetUsers_ToDoUserId",
                table: "Todos");

            migrationBuilder.RenameColumn(
                name: "ToDoUserId",
                table: "Todos",
                newName: "ToDoUSerId");

            migrationBuilder.RenameIndex(
                name: "IX_Todos_ToDoUserId",
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
    }
}
