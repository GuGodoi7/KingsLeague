using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KingsLeague.Migrations
{
    /// <inheritdoc />
    public partial class CreateRelacionamentos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TecnicoId",
                table: "RM99585_TB_TIMES",
                type: "NUMBER(10)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TecnicosTecnicoId",
                table: "RM99585_TB_TIMES",
                type: "NUMBER(10)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TimeId",
                table: "RM99585_TB_PATROCINIOS",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TimesTimeId",
                table: "RM99585_TB_PATROCINIOS",
                type: "NUMBER(10)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TimeId",
                table: "RM99585_TB_Jogadores",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TimesTimeId",
                table: "RM99585_TB_Jogadores",
                type: "NUMBER(10)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RM99585_TB_TIMES_TecnicosTecnicoId",
                table: "RM99585_TB_TIMES",
                column: "TecnicosTecnicoId");

            migrationBuilder.CreateIndex(
                name: "IX_RM99585_TB_PATROCINIOS_TimesTimeId",
                table: "RM99585_TB_PATROCINIOS",
                column: "TimesTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_RM99585_TB_Jogadores_TimesTimeId",
                table: "RM99585_TB_Jogadores",
                column: "TimesTimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_RM99585_TB_Jogadores_RM99585_TB_TIMES_TimesTimeId",
                table: "RM99585_TB_Jogadores",
                column: "TimesTimeId",
                principalTable: "RM99585_TB_TIMES",
                principalColumn: "TimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_RM99585_TB_PATROCINIOS_RM99585_TB_TIMES_TimesTimeId",
                table: "RM99585_TB_PATROCINIOS",
                column: "TimesTimeId",
                principalTable: "RM99585_TB_TIMES",
                principalColumn: "TimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_RM99585_TB_TIMES_RM99585_TB_TECNICOS_TecnicosTecnicoId",
                table: "RM99585_TB_TIMES",
                column: "TecnicosTecnicoId",
                principalTable: "RM99585_TB_TECNICOS",
                principalColumn: "TecnicoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RM99585_TB_Jogadores_RM99585_TB_TIMES_TimesTimeId",
                table: "RM99585_TB_Jogadores");

            migrationBuilder.DropForeignKey(
                name: "FK_RM99585_TB_PATROCINIOS_RM99585_TB_TIMES_TimesTimeId",
                table: "RM99585_TB_PATROCINIOS");

            migrationBuilder.DropForeignKey(
                name: "FK_RM99585_TB_TIMES_RM99585_TB_TECNICOS_TecnicosTecnicoId",
                table: "RM99585_TB_TIMES");

            migrationBuilder.DropIndex(
                name: "IX_RM99585_TB_TIMES_TecnicosTecnicoId",
                table: "RM99585_TB_TIMES");

            migrationBuilder.DropIndex(
                name: "IX_RM99585_TB_PATROCINIOS_TimesTimeId",
                table: "RM99585_TB_PATROCINIOS");

            migrationBuilder.DropIndex(
                name: "IX_RM99585_TB_Jogadores_TimesTimeId",
                table: "RM99585_TB_Jogadores");

            migrationBuilder.DropColumn(
                name: "TecnicoId",
                table: "RM99585_TB_TIMES");

            migrationBuilder.DropColumn(
                name: "TecnicosTecnicoId",
                table: "RM99585_TB_TIMES");

            migrationBuilder.DropColumn(
                name: "TimeId",
                table: "RM99585_TB_PATROCINIOS");

            migrationBuilder.DropColumn(
                name: "TimesTimeId",
                table: "RM99585_TB_PATROCINIOS");

            migrationBuilder.DropColumn(
                name: "TimeId",
                table: "RM99585_TB_Jogadores");

            migrationBuilder.DropColumn(
                name: "TimesTimeId",
                table: "RM99585_TB_Jogadores");
        }
    }
}
