using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CursoApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ALUNO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ALUNO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TURMA",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NUMERO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ANO_LETIVO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NIVEL = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TURMA", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MATRICULA",
                columns: table => new
                {
                    TURMA_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ALUNO_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MATRICULA", x => new { x.TURMA_ID, x.ALUNO_ID });
                    table.ForeignKey(
                        name: "FK_MATRICULA_ALUNO_ALUNO_ID",
                        column: x => x.ALUNO_ID,
                        principalTable: "ALUNO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MATRICULA_TURMA_TURMA_ID",
                        column: x => x.TURMA_ID,
                        principalTable: "TURMA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ALUNO_CPF",
                table: "ALUNO",
                column: "CPF",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ALUNO_EMAIL",
                table: "ALUNO",
                column: "EMAIL",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MATRICULA_ALUNO_ID",
                table: "MATRICULA",
                column: "ALUNO_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MATRICULA");

            migrationBuilder.DropTable(
                name: "ALUNO");

            migrationBuilder.DropTable(
                name: "TURMA");
        }
    }
}
