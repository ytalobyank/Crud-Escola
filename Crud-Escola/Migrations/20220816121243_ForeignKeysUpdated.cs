using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crud_Escola.Migrations
{
    public partial class ForeignKeysUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Turmas_IdSchool",
                table: "Turmas",
                column: "IdSchool");

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_IdClassroom",
                table: "Alunos",
                column: "IdClassroom");

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_IdSchool",
                table: "Alunos",
                column: "IdSchool");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Escolas_IdSchool",
                table: "Alunos",
                column: "IdSchool",
                principalTable: "Escolas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Turmas_IdClassroom",
                table: "Alunos",
                column: "IdClassroom",
                principalTable: "Turmas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Turmas_Escolas_IdSchool",
                table: "Turmas",
                column: "IdSchool",
                principalTable: "Escolas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Escolas_IdSchool",
                table: "Alunos");

            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Turmas_IdClassroom",
                table: "Alunos");

            migrationBuilder.DropForeignKey(
                name: "FK_Turmas_Escolas_IdSchool",
                table: "Turmas");

            migrationBuilder.DropIndex(
                name: "IX_Turmas_IdSchool",
                table: "Turmas");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_IdClassroom",
                table: "Alunos");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_IdSchool",
                table: "Alunos");
        }
    }
}
