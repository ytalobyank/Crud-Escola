using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crud_Escola.Migrations
{
    public partial class CreatedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data",
                table: "Turmas");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Turmas",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Done",
                table: "Turmas",
                newName: "IdSchool");

            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdSchool = table.Column<int>(type: "INTEGER", nullable: false),
                    IdClassroom = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Age = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Escolas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Escolas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Escolas");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Turmas",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "IdSchool",
                table: "Turmas",
                newName: "Done");

            migrationBuilder.AddColumn<DateTime>(
                name: "Data",
                table: "Turmas",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
