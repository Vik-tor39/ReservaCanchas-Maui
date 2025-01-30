﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaveInformationAPI.Migrations
{
    /// <inheritdoc />
    public partial class Changes_Structure_DB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cancha",
                columns: table => new
                {
                    IdCancha = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCancha = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NumeroJugadores = table.Column<int>(type: "int", nullable: false),
                    PrecioPorHora = table.Column<float>(type: "real", nullable: true),
                    HoraApertura = table.Column<TimeSpan>(type: "time", nullable: false),
                    HoraCierre = table.Column<TimeSpan>(type: "time", nullable: false),
                    ImagenCancha = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IdComplejo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cancha", x => x.IdCancha);
                });

            migrationBuilder.CreateTable(
                name: "Complejo",
                columns: table => new
                {
                    IdComplejo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreComplejo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ImagenComplejo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IdAdministrador = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complejo", x => x.IdComplejo);
                });

            migrationBuilder.CreateTable(
                name: "Reserva",
                columns: table => new
                {
                    IdReserva = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraInicio = table.Column<TimeSpan>(type: "time", nullable: false),
                    HoraFin = table.Column<TimeSpan>(type: "time", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdCancha = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserva", x => x.IdReserva);
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
                    Tipo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.IdUsuario);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cancha");

            migrationBuilder.DropTable(
                name: "Complejo");

            migrationBuilder.DropTable(
                name: "Reserva");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
