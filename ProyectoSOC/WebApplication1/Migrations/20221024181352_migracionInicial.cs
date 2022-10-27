using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoSOC.Migrations
{
    public partial class migracionInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioApellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioCorreo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioPasswordAnterior = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioIntentos = table.Column<int>(type: "int", nullable: false),
                    UsuarioCambioPass = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioFechaCambioPass = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioFechaSesion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioFechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioFechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioUsuarioId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioEstado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.UsuarioId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
