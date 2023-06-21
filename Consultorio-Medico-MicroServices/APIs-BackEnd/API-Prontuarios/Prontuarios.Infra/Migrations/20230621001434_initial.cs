using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prontuarios.Infra.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prontuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    MedicoId = table.Column<string>(type: "TEXT", nullable: false),
                    MedicoNome = table.Column<string>(type: "TEXT", nullable: false),
                    MedicoEspecialidade = table.Column<string>(type: "TEXT", nullable: false),
                    PacienteId = table.Column<string>(type: "TEXT", nullable: false),
                    PacienteNome = table.Column<string>(type: "TEXT", nullable: false),
                    TextoProntuario = table.Column<string>(type: "TEXT", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Ativo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prontuarios", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prontuarios");
        }
    }
}
