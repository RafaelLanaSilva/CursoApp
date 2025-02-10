using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CursoApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class revisao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NOME",
                table: "TURMA",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NOME",
                table: "TURMA");
        }
    }
}
