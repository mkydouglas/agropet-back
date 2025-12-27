using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agropet.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class att : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrecoUnitarioCompra",
                table: "Lote");

            migrationBuilder.DropColumn(
                name: "UnidadeComercial",
                table: "Lote");

            migrationBuilder.AddColumn<decimal>(
                name: "PrecoUnitarioCompra",
                table: "Produto",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "UnidadeComercial",
                table: "Produto",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrecoUnitarioCompra",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "UnidadeComercial",
                table: "Produto");

            migrationBuilder.AddColumn<decimal>(
                name: "PrecoUnitarioCompra",
                table: "Lote",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "UnidadeComercial",
                table: "Lote",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
