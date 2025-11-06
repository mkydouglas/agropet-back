using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agropet.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class novastabelasF001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovimentacaoEstoque_Lote_IdLote",
                table: "MovimentacaoEstoque");

            migrationBuilder.AlterColumn<double>(
                name: "Quantidade",
                table: "MovimentacaoEstoque",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "Quantidade",
                table: "Lote",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "FormaPagamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormaPagamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Venda",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QtdeTotalItens = table.Column<int>(type: "int", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Desconto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorPago = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venda", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProdutoVendas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrecoProduto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Desconto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorPago = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdProduto = table.Column<int>(type: "int", nullable: false),
                    IdVenda = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoVendas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProdutoVendas_Produto_IdProduto",
                        column: x => x.IdProduto,
                        principalTable: "Produto",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProdutoVendas_Venda_IdVenda",
                        column: x => x.IdVenda,
                        principalTable: "Venda",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VendaFormaPagamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValorPago = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdVenda = table.Column<int>(type: "int", nullable: false),
                    IdFormaPagamento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendaFormaPagamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VendaFormaPagamento_FormaPagamento_IdFormaPagamento",
                        column: x => x.IdFormaPagamento,
                        principalTable: "FormaPagamento",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VendaFormaPagamento_Venda_IdVenda",
                        column: x => x.IdVenda,
                        principalTable: "Venda",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoVendas_IdProduto",
                table: "ProdutoVendas",
                column: "IdProduto");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoVendas_IdVenda",
                table: "ProdutoVendas",
                column: "IdVenda");

            migrationBuilder.CreateIndex(
                name: "IX_VendaFormaPagamento_IdFormaPagamento",
                table: "VendaFormaPagamento",
                column: "IdFormaPagamento");

            migrationBuilder.CreateIndex(
                name: "IX_VendaFormaPagamento_IdVenda",
                table: "VendaFormaPagamento",
                column: "IdVenda");

            migrationBuilder.AddForeignKey(
                name: "FK_MovimentacaoEstoque_Lote_IdLote",
                table: "MovimentacaoEstoque",
                column: "IdLote",
                principalTable: "Lote",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovimentacaoEstoque_Lote_IdLote",
                table: "MovimentacaoEstoque");

            migrationBuilder.DropTable(
                name: "ProdutoVendas");

            migrationBuilder.DropTable(
                name: "VendaFormaPagamento");

            migrationBuilder.DropTable(
                name: "FormaPagamento");

            migrationBuilder.DropTable(
                name: "Venda");

            migrationBuilder.AlterColumn<int>(
                name: "Quantidade",
                table: "MovimentacaoEstoque",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "Quantidade",
                table: "Lote",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddForeignKey(
                name: "FK_MovimentacaoEstoque_Lote_IdLote",
                table: "MovimentacaoEstoque",
                column: "IdLote",
                principalTable: "Lote",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
