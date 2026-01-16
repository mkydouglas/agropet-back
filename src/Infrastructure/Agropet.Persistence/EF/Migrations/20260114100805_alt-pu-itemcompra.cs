using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agropet.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class altpuitemcompra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Preco",
                table: "ItemCompra",
                newName: "PrecoUnitario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PrecoUnitario",
                table: "ItemCompra",
                newName: "Preco");
        }
    }
}
