using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agropet.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ajustesprop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PrecoUnitario",
                table: "Lote",
                newName: "PrecoUnitarioCompra");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PrecoUnitarioCompra",
                table: "Lote",
                newName: "PrecoUnitario");
        }
    }
}
