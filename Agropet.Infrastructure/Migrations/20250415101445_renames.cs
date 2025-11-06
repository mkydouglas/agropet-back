using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agropet.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class renames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProdutoVendas_Produto_IdProduto",
                table: "ProdutoVendas");

            migrationBuilder.DropForeignKey(
                name: "FK_ProdutoVendas_Venda_IdVenda",
                table: "ProdutoVendas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProdutoVendas",
                table: "ProdutoVendas");

            migrationBuilder.RenameTable(
                name: "ProdutoVendas",
                newName: "ProdutoVenda");

            migrationBuilder.RenameIndex(
                name: "IX_ProdutoVendas_IdVenda",
                table: "ProdutoVenda",
                newName: "IX_ProdutoVenda_IdVenda");

            migrationBuilder.RenameIndex(
                name: "IX_ProdutoVendas_IdProduto",
                table: "ProdutoVenda",
                newName: "IX_ProdutoVenda_IdProduto");

            migrationBuilder.AddColumn<int>(
                name: "IdProduto",
                table: "MovimentacaoEstoque",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Quantidade",
                table: "ProdutoVenda",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProdutoVenda",
                table: "ProdutoVenda",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutoVenda_Produto_IdProduto",
                table: "ProdutoVenda",
                column: "IdProduto",
                principalTable: "Produto",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutoVenda_Venda_IdVenda",
                table: "ProdutoVenda",
                column: "IdVenda",
                principalTable: "Venda",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProdutoVenda_Produto_IdProduto",
                table: "ProdutoVenda");

            migrationBuilder.DropForeignKey(
                name: "FK_ProdutoVenda_Venda_IdVenda",
                table: "ProdutoVenda");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProdutoVenda",
                table: "ProdutoVenda");

            migrationBuilder.DropColumn(
                name: "IdProduto",
                table: "MovimentacaoEstoque");

            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "ProdutoVenda");

            migrationBuilder.RenameTable(
                name: "ProdutoVenda",
                newName: "ProdutoVendas");

            migrationBuilder.RenameIndex(
                name: "IX_ProdutoVenda_IdVenda",
                table: "ProdutoVendas",
                newName: "IX_ProdutoVendas_IdVenda");

            migrationBuilder.RenameIndex(
                name: "IX_ProdutoVenda_IdProduto",
                table: "ProdutoVendas",
                newName: "IX_ProdutoVendas_IdProduto");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProdutoVendas",
                table: "ProdutoVendas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutoVendas_Produto_IdProduto",
                table: "ProdutoVendas",
                column: "IdProduto",
                principalTable: "Produto",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutoVendas_Venda_IdVenda",
                table: "ProdutoVendas",
                column: "IdVenda",
                principalTable: "Venda",
                principalColumn: "Id");
        }
    }
}
