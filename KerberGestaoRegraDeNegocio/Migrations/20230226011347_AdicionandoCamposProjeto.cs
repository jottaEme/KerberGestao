using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KerberGestaoRegraDeNegocio.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoCamposProjeto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "projetos",
                type: "longtext",
                nullable: false,
                collation: "utf8mb4_0900_ai_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "IdCliente",
                table: "projetos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "projetos");

            migrationBuilder.DropColumn(
                name: "IdCliente",
                table: "projetos");
        }
    }
}
