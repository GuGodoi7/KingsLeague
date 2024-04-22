using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KingsLeague.Migrations
{
    /// <inheritdoc />
    public partial class CreateJogadores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RM99585_TB_Jogadores",
                columns: table => new
                {
                    JogadorId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Salario = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    Nacionalidade = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Posicao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Especialidade = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Status = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RM99585_TB_Jogadores", x => x.JogadorId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RM99585_TB_Jogadores");
        }
    }
}
