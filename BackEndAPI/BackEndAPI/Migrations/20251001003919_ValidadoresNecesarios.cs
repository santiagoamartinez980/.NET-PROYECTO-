using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEndAPI.Migrations
{
    /// <inheritdoc />
    public partial class ValidadoresNecesarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TarjetaGrafica_ConsumoWatts",
                table: "Componentes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TipoAlmacenamiento",
                table: "Componentes",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TarjetaGrafica_ConsumoWatts",
                table: "Componentes");

            migrationBuilder.DropColumn(
                name: "TipoAlmacenamiento",
                table: "Componentes");
        }
    }
}
