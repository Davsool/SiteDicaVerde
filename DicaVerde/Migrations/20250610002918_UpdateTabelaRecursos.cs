using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DicaVerde.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTabelaRecursos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "RecursosEducativos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tipo",
                table: "RecursosEducativos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
