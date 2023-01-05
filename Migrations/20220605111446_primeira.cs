using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projetoMarcacoes.Migrations
{
    public partial class primeira : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tclientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tclientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tfuncionarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contacto = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tfuncionarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tservicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Custo = table.Column<double>(type: "float", nullable: false),
                    DuracaoHora = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tservicos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tfuncionario_servico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FuncionarioId = table.Column<int>(type: "int", nullable: false),
                    ServicoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tfuncionario_servico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tfuncionario_servico_Tfuncionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Tfuncionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tfuncionario_servico_Tservicos_ServicoId",
                        column: x => x.ServicoId,
                        principalTable: "Tservicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tmarcacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    Funcionario_ServicoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tmarcacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tmarcacoes_Tclientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Tclientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tmarcacoes_Tfuncionario_servico_Funcionario_ServicoId",
                        column: x => x.Funcionario_ServicoId,
                        principalTable: "Tfuncionario_servico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tfuncionario_servico_FuncionarioId",
                table: "Tfuncionario_servico",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Tfuncionario_servico_ServicoId",
                table: "Tfuncionario_servico",
                column: "ServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tmarcacoes_ClienteId",
                table: "Tmarcacoes",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Tmarcacoes_Funcionario_ServicoId",
                table: "Tmarcacoes",
                column: "Funcionario_ServicoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tmarcacoes");

            migrationBuilder.DropTable(
                name: "Tclientes");

            migrationBuilder.DropTable(
                name: "Tfuncionario_servico");

            migrationBuilder.DropTable(
                name: "Tfuncionarios");

            migrationBuilder.DropTable(
                name: "Tservicos");
        }
    }
}
