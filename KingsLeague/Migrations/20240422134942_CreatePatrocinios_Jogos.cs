using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KingsLeague.Migrations
{
    /// <inheritdoc />
    public partial class CreatePatrocinios_Jogos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RM99585_TB_JOGOS",
                columns: table => new
                {
                    JogoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DataJogo = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    TimeMandante = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    timeVisitante = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    TipoJogo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Publico = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RM99585_TB_JOGOS", x => x.JogoId);
                });

            migrationBuilder.CreateTable(
                name: "RM99585_TB_PATROCINIOS",
                columns: table => new
                {
                    PatrocinioId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Marca = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Verba = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    PrazoContrato = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    TipoContrato = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RM99585_TB_PATROCINIOS", x => x.PatrocinioId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RM99585_TB_JOGOS");

            migrationBuilder.DropTable(
                name: "RM99585_TB_PATROCINIOS");
        }
    }
}
