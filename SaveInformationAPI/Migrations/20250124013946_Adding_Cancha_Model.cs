using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaveInformationAPI.Migrations
{
    /// <inheritdoc />
    public partial class Adding_Cancha_Model : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cancha_Complejo_ComplejoIdComplejo",
                table: "Cancha");

            migrationBuilder.RenameColumn(
                name: "ComplejoIdComplejo",
                table: "Cancha",
                newName: "complejoIdComplejo");

            migrationBuilder.RenameIndex(
                name: "IX_Cancha_ComplejoIdComplejo",
                table: "Cancha",
                newName: "IX_Cancha_complejoIdComplejo");

            migrationBuilder.AlterColumn<string>(
                name: "NombreCancha",
                table: "Cancha",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "ImagenCancha",
                table: "Cancha",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Cancha_Complejo_complejoIdComplejo",
                table: "Cancha",
                column: "complejoIdComplejo",
                principalTable: "Complejo",
                principalColumn: "IdComplejo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cancha_Complejo_complejoIdComplejo",
                table: "Cancha");

            migrationBuilder.RenameColumn(
                name: "complejoIdComplejo",
                table: "Cancha",
                newName: "ComplejoIdComplejo");

            migrationBuilder.RenameIndex(
                name: "IX_Cancha_complejoIdComplejo",
                table: "Cancha",
                newName: "IX_Cancha_ComplejoIdComplejo");

            migrationBuilder.AlterColumn<string>(
                name: "NombreCancha",
                table: "Cancha",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImagenCancha",
                table: "Cancha",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cancha_Complejo_ComplejoIdComplejo",
                table: "Cancha",
                column: "ComplejoIdComplejo",
                principalTable: "Complejo",
                principalColumn: "IdComplejo");
        }
    }
}
