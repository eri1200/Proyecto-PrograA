using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoMvc.DataAccess.Migrations
{
    public partial class DBEri : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bitacoras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EncargoId = table.Column<int>(type: "int", nullable: false),
                    NinoId = table.Column<int>(type: "int", nullable: false),
                    EmpleadoId = table.Column<int>(type: "int", nullable: false),
                    Entrada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Motivo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bitacoras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bitacoras_Empleados_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bitacoras_Encargados_EncargoId",
                        column: x => x.EncargoId,
                        principalTable: "Encargados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bitacoras_Ninos_NinoId",
                        column: x => x.NinoId,
                        principalTable: "Ninos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bitacoras_EmpleadoId",
                table: "Bitacoras",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Bitacoras_EncargoId",
                table: "Bitacoras",
                column: "EncargoId");

            migrationBuilder.CreateIndex(
                name: "IX_Bitacoras_NinoId",
                table: "Bitacoras",
                column: "NinoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bitacoras");
        }
    }
}
