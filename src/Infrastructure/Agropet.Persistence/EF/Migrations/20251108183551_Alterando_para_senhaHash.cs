using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agropet.Persistence.EF.Migrations
{
    /// <inheritdoc />
    public partial class Alterando_para_senhaHash : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Senha",
                table: "Usuario",
                newName: "SenhaHash");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SenhaHash",
                table: "Usuario",
                newName: "Senha");
        }
    }
}
