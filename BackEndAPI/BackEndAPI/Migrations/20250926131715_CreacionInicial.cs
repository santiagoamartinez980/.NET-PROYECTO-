using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEndAPI.Migrations
{
    /// <inheritdoc />
    public partial class CreacionInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Componentes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlImagen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Interfaz = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PotenciaWatts = table.Column<int>(type: "int", nullable: true),
                    TipoMemoria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Socket = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlacaBase_TipoMemoria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Procesador_Socket = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConsumoWatts = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Componentes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Documento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ensamblajes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    ProcesadorId = table.Column<int>(type: "int", nullable: false),
                    PlacaBaseId = table.Column<int>(type: "int", nullable: false),
                    MemoriaRamId = table.Column<int>(type: "int", nullable: false),
                    TarjetaGraficaId = table.Column<int>(type: "int", nullable: true),
                    AlmacenamientoId = table.Column<int>(type: "int", nullable: false),
                    FuentePoderId = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ensamblajes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ensamblajes_Componentes_AlmacenamientoId",
                        column: x => x.AlmacenamientoId,
                        principalTable: "Componentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ensamblajes_Componentes_FuentePoderId",
                        column: x => x.FuentePoderId,
                        principalTable: "Componentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ensamblajes_Componentes_MemoriaRamId",
                        column: x => x.MemoriaRamId,
                        principalTable: "Componentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ensamblajes_Componentes_PlacaBaseId",
                        column: x => x.PlacaBaseId,
                        principalTable: "Componentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ensamblajes_Componentes_ProcesadorId",
                        column: x => x.ProcesadorId,
                        principalTable: "Componentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ensamblajes_Componentes_TarjetaGraficaId",
                        column: x => x.TarjetaGraficaId,
                        principalTable: "Componentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ensamblajes_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ensamblajes_AlmacenamientoId",
                table: "Ensamblajes",
                column: "AlmacenamientoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ensamblajes_FuentePoderId",
                table: "Ensamblajes",
                column: "FuentePoderId");

            migrationBuilder.CreateIndex(
                name: "IX_Ensamblajes_MemoriaRamId",
                table: "Ensamblajes",
                column: "MemoriaRamId");

            migrationBuilder.CreateIndex(
                name: "IX_Ensamblajes_PlacaBaseId",
                table: "Ensamblajes",
                column: "PlacaBaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Ensamblajes_ProcesadorId",
                table: "Ensamblajes",
                column: "ProcesadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Ensamblajes_TarjetaGraficaId",
                table: "Ensamblajes",
                column: "TarjetaGraficaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ensamblajes_UsuarioId",
                table: "Ensamblajes",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ensamblajes");

            migrationBuilder.DropTable(
                name: "Componentes");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
