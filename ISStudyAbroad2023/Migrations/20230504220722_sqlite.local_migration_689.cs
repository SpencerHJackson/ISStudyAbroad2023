using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ISStudyAbroad2023.Migrations
{
    public partial class sqlitelocal_migration_689 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Thoughts",
                columns: table => new
                {
                    ThoughtId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PersonStudentId = table.Column<int>(type: "INTEGER", nullable: false),
                    ThoughtDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Thoughts", x => x.ThoughtId);
                    table.ForeignKey(
                        name: "FK_Thoughts_Students_PersonStudentId",
                        column: x => x.PersonStudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Thoughts_PersonStudentId",
                table: "Thoughts",
                column: "PersonStudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Thoughts");
        }
    }
}
