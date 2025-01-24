using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaveInformationAPI.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Complejo",
                columns: table => new
                {
                    IdComplejo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreComplejo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ImagenComplejo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IdAdministrador = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complejo", x => x.IdComplejo);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreUsuario = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CorreoUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordUsuario = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    tipoUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComplejosAdministrados = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Cancha",
                columns: table => new
                {
                    IdCancha = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCancha = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NumeroJugadores = table.Column<int>(type: "int", nullable: false),
                    PrecioPorHora = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HoraApertura = table.Column<TimeSpan>(type: "time", nullable: false),
                    HoraCierre = table.Column<TimeSpan>(type: "time", nullable: false),
                    ImagenCancha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdComplejo = table.Column<int>(type: "int", nullable: false),
                    ComplejoIdComplejo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cancha", x => x.IdCancha);
                    table.ForeignKey(
                        name: "FK_Cancha_Complejo_ComplejoIdComplejo",
                        column: x => x.ComplejoIdComplejo,
                        principalTable: "Complejo",
                        principalColumn: "IdComplejo");
                });

            migrationBuilder.CreateTable(
                name: "Reserva",
                columns: table => new
                {
                    IdReserva = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraInicio = table.Column<TimeSpan>(type: "time", nullable: false),
                    HoraFin = table.Column<TimeSpan>(type: "time", nullable: false),
                    canchaIdCancha = table.Column<int>(type: "int", nullable: true),
                    IdCancha = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserva", x => x.IdReserva);
                    table.ForeignKey(
                        name: "FK_Reserva_Cancha_canchaIdCancha",
                        column: x => x.canchaIdCancha,
                        principalTable: "Cancha",
                        principalColumn: "IdCancha");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cancha_ComplejoIdComplejo",
                table: "Cancha",
                column: "ComplejoIdComplejo");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_canchaIdCancha",
                table: "Reserva",
                column: "canchaIdCancha");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reserva");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Cancha");

            migrationBuilder.DropTable(
                name: "Complejo");
        }
    }
}
