using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaveInformationAPI.Migrations
{
    /// <inheritdoc />
    public partial class Models_Reference_Correction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "usuarioIdUsuario",
                table: "Reserva",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "administradorIdUsuario",
                table: "Complejo",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_usuarioIdUsuario",
                table: "Reserva",
                column: "usuarioIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Complejo_administradorIdUsuario",
                table: "Complejo",
                column: "administradorIdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Complejo_Usuario_administradorIdUsuario",
                table: "Complejo",
                column: "administradorIdUsuario",
                principalTable: "Usuario",
                principalColumn: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Usuario_usuarioIdUsuario",
                table: "Reserva",
                column: "usuarioIdUsuario",
                principalTable: "Usuario",
                principalColumn: "IdUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Complejo_Usuario_administradorIdUsuario",
                table: "Complejo");

            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Usuario_usuarioIdUsuario",
                table: "Reserva");

            migrationBuilder.DropIndex(
                name: "IX_Reserva_usuarioIdUsuario",
                table: "Reserva");

            migrationBuilder.DropIndex(
                name: "IX_Complejo_administradorIdUsuario",
                table: "Complejo");

            migrationBuilder.DropColumn(
                name: "usuarioIdUsuario",
                table: "Reserva");

            migrationBuilder.DropColumn(
                name: "administradorIdUsuario",
                table: "Complejo");
        }
    }
}
