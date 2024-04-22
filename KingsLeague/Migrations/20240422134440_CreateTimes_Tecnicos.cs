using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KingsLeague.Migrations
{
    /// <inheritdoc />
    public partial class CreateTimes_Tecnicos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RM99585_TB_TECNICOS",
                columns: table => new
                {
                    TecnicoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Salario = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    Nacionalidade = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    TempoCarreira = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Estrategia = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RM99585_TB_TECNICOS", x => x.TecnicoId);
                });

            migrationBuilder.CreateTable(
                name: "RM99585_TB_TIMES",
                columns: table => new
                {
                    TimeId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DataFundacao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Presidencia = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Estadio = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RM99585_TB_TIMES", x => x.TimeId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RM99585_TB_TECNICOS");

            migrationBuilder.DropTable(
                name: "RM99585_TB_TIMES");
        }
    }
}
