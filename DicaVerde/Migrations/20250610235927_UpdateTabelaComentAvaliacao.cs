using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DicaVerde.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTabelaComentAvaliacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Avaliacoes_AspNetUsers_UsuarioId",
                table: "Avaliacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_AspNetUsers_UsuarioId",
                table: "Comentarios");

            migrationBuilder.DropIndex(
                name: "IX_Comentarios_UsuarioId",
                table: "Comentarios");

            migrationBuilder.DropIndex(
                name: "IX_Avaliacoes_UsuarioId",
                table: "Avaliacoes");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Comentarios");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Avaliacoes");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Comentarios",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Avaliacoes",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_UserId",
                table: "Comentarios",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_UserId",
                table: "Avaliacoes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliacoes_AspNetUsers_UserId",
                table: "Avaliacoes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_AspNetUsers_UserId",
                table: "Comentarios",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Avaliacoes_AspNetUsers_UserId",
                table: "Avaliacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_AspNetUsers_UserId",
                table: "Comentarios");

            migrationBuilder.DropIndex(
                name: "IX_Comentarios_UserId",
                table: "Comentarios");

            migrationBuilder.DropIndex(
                name: "IX_Avaliacoes_UserId",
                table: "Avaliacoes");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Comentarios",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioId",
                table: "Comentarios",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Avaliacoes",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioId",
                table: "Avaliacoes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_UsuarioId",
                table: "Comentarios",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_UsuarioId",
                table: "Avaliacoes",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliacoes_AspNetUsers_UsuarioId",
                table: "Avaliacoes",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_AspNetUsers_UsuarioId",
                table: "Comentarios",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
