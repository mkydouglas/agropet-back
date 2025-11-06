using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agropet.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ajustes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovimentacaoEstoque_Produto_IdProduto",
                table: "MovimentacaoEstoque");

            migrationBuilder.DropIndex(
                name: "IX_MovimentacaoEstoque_IdProduto",
                table: "MovimentacaoEstoque");

            migrationBuilder.DropColumn(
                name: "DataMovimentacao",
                table: "MovimentacaoEstoque");

            migrationBuilder.DropColumn(
                name: "IdProduto",
                table: "MovimentacaoEstoque");

            migrationBuilder.AlterColumn<long>(
                name: "CodigoBarras",
                table: "Produto",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<int>(
                name: "ProdutoId",
                table: "MovimentacaoEstoque",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UnidadeComercial",
                table: "Lote",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataEntrada",
                table: "Lote",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateIndex(
                name: "IX_MovimentacaoEstoque_ProdutoId",
                table: "MovimentacaoEstoque",
                column: "ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovimentacaoEstoque_Produto_ProdutoId",
                table: "MovimentacaoEstoque",
                column: "ProdutoId",
                principalTable: "Produto",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovimentacaoEstoque_Produto_ProdutoId",
                table: "MovimentacaoEstoque");

            migrationBuilder.DropIndex(
                name: "IX_MovimentacaoEstoque_ProdutoId",
                table: "MovimentacaoEstoque");

            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "MovimentacaoEstoque");

            migrationBuilder.AlterColumn<double>(
                name: "CodigoBarras",
                table: "Produto",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataMovimentacao",
                table: "MovimentacaoEstoque",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "IdProduto",
                table: "MovimentacaoEstoque",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "UnidadeComercial",
                table: "Lote",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataEntrada",
                table: "Lote",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MovimentacaoEstoque_IdProduto",
                table: "MovimentacaoEstoque",
                column: "IdProduto");

            migrationBuilder.AddForeignKey(
                name: "FK_MovimentacaoEstoque_Produto_IdProduto",
                table: "MovimentacaoEstoque",
                column: "IdProduto",
                principalTable: "Produto",
                principalColumn: "Id");
        }
    }
}
