using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agropet.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class removendoRelacionamentoLote : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EstoqueLote_Lote_LoteId",
                table: "EstoqueLote");

            migrationBuilder.DropForeignKey(
                name: "FK_FornecedorLote_Lote_LoteId",
                table: "FornecedorLote");

            migrationBuilder.DropIndex(
                name: "IX_FornecedorLote_LoteId",
                table: "FornecedorLote");

            migrationBuilder.DropIndex(
                name: "IX_EstoqueLote_LoteId",
                table: "EstoqueLote");

            migrationBuilder.DropColumn(
                name: "LoteId",
                table: "FornecedorLote");

            migrationBuilder.DropColumn(
                name: "LoteId",
                table: "EstoqueLote");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LoteId",
                table: "FornecedorLote",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoteId",
                table: "EstoqueLote",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FornecedorLote_LoteId",
                table: "FornecedorLote",
                column: "LoteId");

            migrationBuilder.CreateIndex(
                name: "IX_EstoqueLote_LoteId",
                table: "EstoqueLote",
                column: "LoteId");

            migrationBuilder.AddForeignKey(
                name: "FK_EstoqueLote_Lote_LoteId",
                table: "EstoqueLote",
                column: "LoteId",
                principalTable: "Lote",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FornecedorLote_Lote_LoteId",
                table: "FornecedorLote",
                column: "LoteId",
                principalTable: "Lote",
                principalColumn: "Id");
        }
    }
}
