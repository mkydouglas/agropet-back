using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agropet.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class att2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EstoqueLote_Estoque_IdEstoque",
                table: "EstoqueLote");

            migrationBuilder.DropForeignKey(
                name: "FK_EstoqueLote_Produto_IdProduto",
                table: "EstoqueLote");

            migrationBuilder.DropForeignKey(
                name: "FK_FornecedorLote_Fornecedor_IdFornecedor",
                table: "FornecedorLote");

            migrationBuilder.DropForeignKey(
                name: "FK_FornecedorLote_Produto_IdProduto",
                table: "FornecedorLote");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FornecedorLote",
                table: "FornecedorLote");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EstoqueLote",
                table: "EstoqueLote");

            migrationBuilder.RenameTable(
                name: "FornecedorLote",
                newName: "FornecedorProduto");

            migrationBuilder.RenameTable(
                name: "EstoqueLote",
                newName: "EstoqueProduto");

            migrationBuilder.RenameIndex(
                name: "IX_FornecedorLote_IdProduto",
                table: "FornecedorProduto",
                newName: "IX_FornecedorProduto_IdProduto");

            migrationBuilder.RenameIndex(
                name: "IX_FornecedorLote_IdFornecedor",
                table: "FornecedorProduto",
                newName: "IX_FornecedorProduto_IdFornecedor");

            migrationBuilder.RenameIndex(
                name: "IX_EstoqueLote_IdProduto",
                table: "EstoqueProduto",
                newName: "IX_EstoqueProduto_IdProduto");

            migrationBuilder.RenameIndex(
                name: "IX_EstoqueLote_IdEstoque",
                table: "EstoqueProduto",
                newName: "IX_EstoqueProduto_IdEstoque");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FornecedorProduto",
                table: "FornecedorProduto",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EstoqueProduto",
                table: "EstoqueProduto",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EstoqueProduto_Estoque_IdEstoque",
                table: "EstoqueProduto",
                column: "IdEstoque",
                principalTable: "Estoque",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EstoqueProduto_Produto_IdProduto",
                table: "EstoqueProduto",
                column: "IdProduto",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FornecedorProduto_Fornecedor_IdFornecedor",
                table: "FornecedorProduto",
                column: "IdFornecedor",
                principalTable: "Fornecedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FornecedorProduto_Produto_IdProduto",
                table: "FornecedorProduto",
                column: "IdProduto",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EstoqueProduto_Estoque_IdEstoque",
                table: "EstoqueProduto");

            migrationBuilder.DropForeignKey(
                name: "FK_EstoqueProduto_Produto_IdProduto",
                table: "EstoqueProduto");

            migrationBuilder.DropForeignKey(
                name: "FK_FornecedorProduto_Fornecedor_IdFornecedor",
                table: "FornecedorProduto");

            migrationBuilder.DropForeignKey(
                name: "FK_FornecedorProduto_Produto_IdProduto",
                table: "FornecedorProduto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FornecedorProduto",
                table: "FornecedorProduto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EstoqueProduto",
                table: "EstoqueProduto");

            migrationBuilder.RenameTable(
                name: "FornecedorProduto",
                newName: "FornecedorLote");

            migrationBuilder.RenameTable(
                name: "EstoqueProduto",
                newName: "EstoqueLote");

            migrationBuilder.RenameIndex(
                name: "IX_FornecedorProduto_IdProduto",
                table: "FornecedorLote",
                newName: "IX_FornecedorLote_IdProduto");

            migrationBuilder.RenameIndex(
                name: "IX_FornecedorProduto_IdFornecedor",
                table: "FornecedorLote",
                newName: "IX_FornecedorLote_IdFornecedor");

            migrationBuilder.RenameIndex(
                name: "IX_EstoqueProduto_IdProduto",
                table: "EstoqueLote",
                newName: "IX_EstoqueLote_IdProduto");

            migrationBuilder.RenameIndex(
                name: "IX_EstoqueProduto_IdEstoque",
                table: "EstoqueLote",
                newName: "IX_EstoqueLote_IdEstoque");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FornecedorLote",
                table: "FornecedorLote",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EstoqueLote",
                table: "EstoqueLote",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EstoqueLote_Estoque_IdEstoque",
                table: "EstoqueLote",
                column: "IdEstoque",
                principalTable: "Estoque",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EstoqueLote_Produto_IdProduto",
                table: "EstoqueLote",
                column: "IdProduto",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FornecedorLote_Fornecedor_IdFornecedor",
                table: "FornecedorLote",
                column: "IdFornecedor",
                principalTable: "Fornecedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FornecedorLote_Produto_IdProduto",
                table: "FornecedorLote",
                column: "IdProduto",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
