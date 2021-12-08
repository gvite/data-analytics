using Microsoft.EntityFrameworkCore.Migrations;

namespace PuntosVerdes.Migrations
{
    public partial class AddTypePuntoVerde : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PuntoverdeMaterial_Material_MaterialId",
                table: "PuntoverdeMaterial");

            migrationBuilder.DropForeignKey(
                name: "FK_PuntoverdeMaterial_PuntoVerde_PuntoVerdeId",
                table: "PuntoverdeMaterial");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PuntoverdeMaterial",
                table: "PuntoverdeMaterial");

            migrationBuilder.RenameTable(
                name: "PuntoverdeMaterial",
                newName: "PuntoverdeMateriales");

            migrationBuilder.RenameIndex(
                name: "IX_PuntoverdeMaterial_PuntoVerdeId",
                table: "PuntoverdeMateriales",
                newName: "IX_PuntoverdeMateriales_PuntoVerdeId");

            migrationBuilder.RenameIndex(
                name: "IX_PuntoverdeMaterial_MaterialId",
                table: "PuntoverdeMateriales",
                newName: "IX_PuntoverdeMateriales_MaterialId");

            migrationBuilder.AddColumn<string>(
                name: "Tipo",
                table: "PuntoVerde",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PuntoverdeMateriales",
                table: "PuntoverdeMateriales",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PuntoverdeMateriales_Material_MaterialId",
                table: "PuntoverdeMateriales",
                column: "MaterialId",
                principalTable: "Material",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PuntoverdeMateriales_PuntoVerde_PuntoVerdeId",
                table: "PuntoverdeMateriales",
                column: "PuntoVerdeId",
                principalTable: "PuntoVerde",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PuntoverdeMateriales_Material_MaterialId",
                table: "PuntoverdeMateriales");

            migrationBuilder.DropForeignKey(
                name: "FK_PuntoverdeMateriales_PuntoVerde_PuntoVerdeId",
                table: "PuntoverdeMateriales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PuntoverdeMateriales",
                table: "PuntoverdeMateriales");

            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "PuntoVerde");

            migrationBuilder.RenameTable(
                name: "PuntoverdeMateriales",
                newName: "PuntoverdeMaterial");

            migrationBuilder.RenameIndex(
                name: "IX_PuntoverdeMateriales_PuntoVerdeId",
                table: "PuntoverdeMaterial",
                newName: "IX_PuntoverdeMaterial_PuntoVerdeId");

            migrationBuilder.RenameIndex(
                name: "IX_PuntoverdeMateriales_MaterialId",
                table: "PuntoverdeMaterial",
                newName: "IX_PuntoverdeMaterial_MaterialId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PuntoverdeMaterial",
                table: "PuntoverdeMaterial",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PuntoverdeMaterial_Material_MaterialId",
                table: "PuntoverdeMaterial",
                column: "MaterialId",
                principalTable: "Material",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PuntoverdeMaterial_PuntoVerde_PuntoVerdeId",
                table: "PuntoverdeMaterial",
                column: "PuntoVerdeId",
                principalTable: "PuntoVerde",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
