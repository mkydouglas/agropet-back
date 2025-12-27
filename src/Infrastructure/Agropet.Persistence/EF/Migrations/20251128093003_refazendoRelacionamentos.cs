using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agropet.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class refazendoRelacionamentos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EstoqueLote_Lote_IdLote",
                table: "EstoqueLote");

            migrationBuilder.DropForeignKey(
                name: "FK_FornecedorLote_Lote_IdLote",
                table: "FornecedorLote");

            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Lote_IdLote",
                table: "Produto");

            migrationBuilder.DropIndex(
                name: "IX_Produto_IdLote",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "IdLote",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "DataEntrada",
                table: "Lote");

            migrationBuilder.RenameColumn(
                name: "IdLote",
                table: "FornecedorLote",
                newName: "IdProduto");

            migrationBuilder.RenameIndex(
                name: "IX_FornecedorLote_IdLote",
                table: "FornecedorLote",
                newName: "IX_FornecedorLote_IdProduto");

            migrationBuilder.RenameColumn(
                name: "IdLote",
                table: "EstoqueLote",
                newName: "IdProduto");

            migrationBuilder.RenameIndex(
                name: "IX_EstoqueLote_IdLote",
                table: "EstoqueLote",
                newName: "IX_EstoqueLote_IdProduto");

            migrationBuilder.AlterColumn<string>(
                name: "Numero",
                table: "Lote",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataValidade",
                table: "Lote",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataFabricacao",
                table: "Lote",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdProduto",
                table: "Lote",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LoteId",
                table: "FornecedorLote",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Fornecedor",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LoteId",
                table: "EstoqueLote",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Compra",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroNotaFiscal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuantidadeItensComprados = table.Column<int>(type: "int", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdFornecedor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Compra_Fornecedor_IdFornecedor",
                        column: x => x.IdFornecedor,
                        principalTable: "Fornecedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Compra_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemCompra",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdCompra = table.Column<int>(type: "int", nullable: false),
                    IdProduto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCompra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemCompra_Compra_IdCompra",
                        column: x => x.IdCompra,
                        principalTable: "Compra",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemCompra_Produto_IdProduto",
                        column: x => x.IdProduto,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lote_IdProduto",
                table: "Lote",
                column: "IdProduto");

            migrationBuilder.CreateIndex(
                name: "IX_FornecedorLote_LoteId",
                table: "FornecedorLote",
                column: "LoteId");

            migrationBuilder.CreateIndex(
                name: "IX_Fornecedor_UsuarioId",
                table: "Fornecedor",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_EstoqueLote_LoteId",
                table: "EstoqueLote",
                column: "LoteId");

            migrationBuilder.CreateIndex(
                name: "IX_Compra_IdFornecedor",
                table: "Compra",
                column: "IdFornecedor");

            migrationBuilder.CreateIndex(
                name: "IX_Compra_IdUsuario",
                table: "Compra",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCompra_IdCompra",
                table: "ItemCompra",
                column: "IdCompra");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCompra_IdProduto",
                table: "ItemCompra",
                column: "IdProduto");

            migrationBuilder.AddForeignKey(
                name: "FK_EstoqueLote_Lote_LoteId",
                table: "EstoqueLote",
                column: "LoteId",
                principalTable: "Lote",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EstoqueLote_Produto_IdProduto",
                table: "EstoqueLote",
                column: "IdProduto",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Fornecedor_Usuario_UsuarioId",
                table: "Fornecedor",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FornecedorLote_Lote_LoteId",
                table: "FornecedorLote",
                column: "LoteId",
                principalTable: "Lote",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FornecedorLote_Produto_IdProduto",
                table: "FornecedorLote",
                column: "IdProduto",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lote_Produto_IdProduto",
                table: "Lote",
                column: "IdProduto",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EstoqueLote_Lote_LoteId",
                table: "EstoqueLote");

            migrationBuilder.DropForeignKey(
                name: "FK_EstoqueLote_Produto_IdProduto",
                table: "EstoqueLote");

            migrationBuilder.DropForeignKey(
                name: "FK_Fornecedor_Usuario_UsuarioId",
                table: "Fornecedor");

            migrationBuilder.DropForeignKey(
                name: "FK_FornecedorLote_Lote_LoteId",
                table: "FornecedorLote");

            migrationBuilder.DropForeignKey(
                name: "FK_FornecedorLote_Produto_IdProduto",
                table: "FornecedorLote");

            migrationBuilder.DropForeignKey(
                name: "FK_Lote_Produto_IdProduto",
                table: "Lote");

            migrationBuilder.DropTable(
                name: "ItemCompra");

            migrationBuilder.DropTable(
                name: "Compra");

            migrationBuilder.DropIndex(
                name: "IX_Lote_IdProduto",
                table: "Lote");

            migrationBuilder.DropIndex(
                name: "IX_FornecedorLote_LoteId",
                table: "FornecedorLote");

            migrationBuilder.DropIndex(
                name: "IX_Fornecedor_UsuarioId",
                table: "Fornecedor");

            migrationBuilder.DropIndex(
                name: "IX_EstoqueLote_LoteId",
                table: "EstoqueLote");

            migrationBuilder.DropColumn(
                name: "IdProduto",
                table: "Lote");

            migrationBuilder.DropColumn(
                name: "LoteId",
                table: "FornecedorLote");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Fornecedor");

            migrationBuilder.DropColumn(
                name: "LoteId",
                table: "EstoqueLote");

            migrationBuilder.RenameColumn(
                name: "IdProduto",
                table: "FornecedorLote",
                newName: "IdLote");

            migrationBuilder.RenameIndex(
                name: "IX_FornecedorLote_IdProduto",
                table: "FornecedorLote",
                newName: "IX_FornecedorLote_IdLote");

            migrationBuilder.RenameColumn(
                name: "IdProduto",
                table: "EstoqueLote",
                newName: "IdLote");

            migrationBuilder.RenameIndex(
                name: "IX_EstoqueLote_IdProduto",
                table: "EstoqueLote",
                newName: "IX_EstoqueLote_IdLote");

            migrationBuilder.AddColumn<int>(
                name: "IdLote",
                table: "Produto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Numero",
                table: "Lote",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataValidade",
                table: "Lote",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataFabricacao",
                table: "Lote",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataEntrada",
                table: "Lote",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produto_IdLote",
                table: "Produto",
                column: "IdLote");

            migrationBuilder.AddForeignKey(
                name: "FK_EstoqueLote_Lote_IdLote",
                table: "EstoqueLote",
                column: "IdLote",
                principalTable: "Lote",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FornecedorLote_Lote_IdLote",
                table: "FornecedorLote",
                column: "IdLote",
                principalTable: "Lote",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Lote_IdLote",
                table: "Produto",
                column: "IdLote",
                principalTable: "Lote",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
