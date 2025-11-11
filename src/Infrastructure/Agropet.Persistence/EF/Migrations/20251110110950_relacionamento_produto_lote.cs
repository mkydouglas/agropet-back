using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agropet.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class relacionamento_produto_lote : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdLote",
                table: "Produto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Lote",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantidade = table.Column<double>(type: "float", nullable: false),
                    UnidadeComercial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrecoUnitarioCompra = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataFabricacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataValidade = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataEntrada = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lote", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produto_IdLote",
                table: "Produto",
                column: "IdLote");

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Lote_IdLote",
                table: "Produto",
                column: "IdLote",
                principalTable: "Lote",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Lote_IdLote",
                table: "Produto");

            migrationBuilder.DropTable(
                name: "Lote");

            migrationBuilder.DropIndex(
                name: "IX_Produto_IdLote",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "IdLote",
                table: "Produto");
        }
    }
}
