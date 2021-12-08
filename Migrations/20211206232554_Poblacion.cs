using Microsoft.EntityFrameworkCore.Migrations;

namespace PuntosVerdes.Migrations
{
    public partial class Poblacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Poblacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantidad = table.Column<long>(type: "bigint", nullable: false),
                    Anio = table.Column<int>(type: "int", nullable: false),
                    ComunaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poblacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Poblacion_Comuna_ComunaId",
                        column: x => x.ComunaId,
                        principalTable: "Comuna",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Poblacion_ComunaId",
                table: "Poblacion",
                column: "ComunaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Poblacion");
        }
    }
}
