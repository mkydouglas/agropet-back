using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agropet.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class relacionamento_lotefornecedorestoque : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estoque",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estoque", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fornecedor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNPJ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RazaoSocial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomeFantasia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstoqueLote",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEstoque = table.Column<int>(type: "int", nullable: false),
                    IdLote = table.Column<int>(type: "int", nullable: false),
                    QuantidadeProduto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstoqueLote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EstoqueLote_Estoque_IdEstoque",
                        column: x => x.IdEstoque,
                        principalTable: "Estoque",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EstoqueLote_Lote_IdLote",
                        column: x => x.IdLote,
                        principalTable: "Lote",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FornecedorLote",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdFornecedor = table.Column<int>(type: "int", nullable: false),
                    IdLote = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FornecedorLote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FornecedorLote_Fornecedor_IdFornecedor",
                        column: x => x.IdFornecedor,
                        principalTable: "Fornecedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FornecedorLote_Lote_IdLote",
                        column: x => x.IdLote,
                        principalTable: "Lote",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EstoqueLote_IdEstoque",
                table: "EstoqueLote",
                column: "IdEstoque");

            migrationBuilder.CreateIndex(
                name: "IX_EstoqueLote_IdLote",
                table: "EstoqueLote",
                column: "IdLote");

            migrationBuilder.CreateIndex(
                name: "IX_FornecedorLote_IdFornecedor",
                table: "FornecedorLote",
                column: "IdFornecedor");

            migrationBuilder.CreateIndex(
                name: "IX_FornecedorLote_IdLote",
                table: "FornecedorLote",
                column: "IdLote");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EstoqueLote");

            migrationBuilder.DropTable(
                name: "FornecedorLote");

            migrationBuilder.DropTable(
                name: "Estoque");

            migrationBuilder.DropTable(
                name: "Fornecedor");
        }
    }
}
