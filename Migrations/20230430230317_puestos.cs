using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PARCIAL1.Migrations
{
    /// <inheritdoc />
    public partial class puestos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "apellido",
                table: "Puestos");

            migrationBuilder.DropColumn(
                name: "name",
                table: "Puestos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "apellido",
                table: "Puestos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "Puestos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
