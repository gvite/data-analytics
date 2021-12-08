using Microsoft.EntityFrameworkCore.Migrations;

namespace PuntosVerdes.Migrations
{
    public partial class InitMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Barrio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barrio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comuna",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comuna", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cooperativa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cooperativa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Material",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PuntoVerde",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitud = table.Column<float>(type: "real", nullable: false),
                    Longitud = table.Column<float>(type: "real", nullable: false),
                    Calle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Calle2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BarrioId = table.Column<int>(type: "int", nullable: false),
                    CooperativaId = table.Column<int>(type: "int", nullable: false),
                    ComunaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PuntoVerde", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PuntoVerde_Barrio_BarrioId",
                        column: x => x.BarrioId,
                        principalTable: "Barrio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PuntoVerde_Comuna_ComunaId",
                        column: x => x.ComunaId,
                        principalTable: "Comuna",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PuntoVerde_Cooperativa_CooperativaId",
                        column: x => x.CooperativaId,
                        principalTable: "Cooperativa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PuntoverdeMaterial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PuntoVerdeId = table.Column<int>(type: "int", nullable: false),
                    MaterialId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PuntoverdeMaterial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PuntoverdeMaterial_Material_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Material",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PuntoverdeMaterial_PuntoVerde_PuntoVerdeId",
                        column: x => x.PuntoVerdeId,
                        principalTable: "PuntoVerde",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecoleccionMateriales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Anio = table.Column<int>(type: "int", nullable: false),
                    Mes = table.Column<int>(type: "int", nullable: false),
                    Pesaje = table.Column<float>(type: "real", nullable: false),
                    PuntoVerdeId = table.Column<int>(type: "int", nullable: false),
                    MaterialId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecoleccionMateriales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecoleccionMateriales_Material_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Material",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecoleccionMateriales_PuntoVerde_PuntoVerdeId",
                        column: x => x.PuntoVerdeId,
                        principalTable: "PuntoVerde",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Visitas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Anio = table.Column<int>(type: "int", nullable: false),
                    Mes = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    PuntoVerdeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Visitas_PuntoVerde_PuntoVerdeId",
                        column: x => x.PuntoVerdeId,
                        principalTable: "PuntoVerde",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PuntoVerde_BarrioId",
                table: "PuntoVerde",
                column: "BarrioId");

            migrationBuilder.CreateIndex(
                name: "IX_PuntoVerde_ComunaId",
                table: "PuntoVerde",
                column: "ComunaId");

            migrationBuilder.CreateIndex(
                name: "IX_PuntoVerde_CooperativaId",
                table: "PuntoVerde",
                column: "CooperativaId");

            migrationBuilder.CreateIndex(
                name: "IX_PuntoverdeMaterial_MaterialId",
                table: "PuntoverdeMaterial",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_PuntoverdeMaterial_PuntoVerdeId",
                table: "PuntoverdeMaterial",
                column: "PuntoVerdeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecoleccionMateriales_MaterialId",
                table: "RecoleccionMateriales",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_RecoleccionMateriales_PuntoVerdeId",
                table: "RecoleccionMateriales",
                column: "PuntoVerdeId");

            migrationBuilder.CreateIndex(
                name: "IX_Visitas_PuntoVerdeId",
                table: "Visitas",
                column: "PuntoVerdeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PuntoverdeMaterial");

            migrationBuilder.DropTable(
                name: "RecoleccionMateriales");

            migrationBuilder.DropTable(
                name: "Visitas");

            migrationBuilder.DropTable(
                name: "Material");

            migrationBuilder.DropTable(
                name: "PuntoVerde");

            migrationBuilder.DropTable(
                name: "Barrio");

            migrationBuilder.DropTable(
                name: "Comuna");

            migrationBuilder.DropTable(
                name: "Cooperativa");
        }
    }
}
