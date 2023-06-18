using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prontuarios.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Prontuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prontuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TextoProntuario = table.Column<string>(type: "TEXT", nullable: false),
                    MedicoId = table.Column<string>(type: "TEXT", nullable: true),
                    ClienteId = table.Column<string>(type: "TEXT", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Ativo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prontuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prontuarios_CadClientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "CadClientes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Prontuarios_CadMedicos_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "CadMedicos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prontuarios_ClienteId",
                table: "Prontuarios",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Prontuarios_MedicoId",
                table: "Prontuarios",
                column: "MedicoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prontuarios");
        }
    }
}
