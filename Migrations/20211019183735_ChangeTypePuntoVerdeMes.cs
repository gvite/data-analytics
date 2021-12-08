using Microsoft.EntityFrameworkCore.Migrations;

namespace PuntosVerdes.Migrations
{
    public partial class ChangeTypePuntoVerdeMes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Mes",
                table: "RecoleccionMateriales",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Mes",
                table: "RecoleccionMateriales",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
