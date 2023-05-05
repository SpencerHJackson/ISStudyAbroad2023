using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ISStudyAbroad2023.Migrations
{
    public partial class sqlitelocal_migration_445 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Thoughts_Students_PersonStudentId",
                table: "Thoughts");

            migrationBuilder.RenameColumn(
                name: "PersonStudentId",
                table: "Thoughts",
                newName: "StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Thoughts_PersonStudentId",
                table: "Thoughts",
                newName: "IX_Thoughts_StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Thoughts_Students_StudentId",
                table: "Thoughts",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Thoughts_Students_StudentId",
                table: "Thoughts");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Thoughts",
                newName: "PersonStudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Thoughts_StudentId",
                table: "Thoughts",
                newName: "IX_Thoughts_PersonStudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Thoughts_Students_PersonStudentId",
                table: "Thoughts",
                column: "PersonStudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
