using Microsoft.EntityFrameworkCore.Migrations;

namespace Datos.Migrations
{
    public partial class AddTablas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pasajeros",
                columns: table => new
                {
                    Identificacion = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pasajeros", x => x.Identificacion);
                });

            migrationBuilder.CreateTable(
                name: "Tiquetes",
                columns: table => new
                {
                    TiqueteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identificacion = table.Column<int>(nullable: false),
                    Ruta = table.Column<string>(nullable: true),
                    Valor = table.Column<int>(nullable: false),
                    PasajeroIdentificacion = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tiquetes", x => x.TiqueteId);
                    table.ForeignKey(
                        name: "FK_Tiquetes_Pasajeros_PasajeroIdentificacion",
                        column: x => x.PasajeroIdentificacion,
                        principalTable: "Pasajeros",
                        principalColumn: "Identificacion",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tiquetes_PasajeroIdentificacion",
                table: "Tiquetes",
                column: "PasajeroIdentificacion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tiquetes");

            migrationBuilder.DropTable(
                name: "Pasajeros");
        }
    }
}
