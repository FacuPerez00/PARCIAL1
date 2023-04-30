using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PARCIAL1.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    apellido = table.Column<string>(type: "TEXT", nullable: false),
                    edad = table.Column<int>(type: "INTEGER", nullable: false),
                    sueldo = table.Column<int>(type: "INTEGER", nullable: false),
                    Ambiguedad = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Puestos",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    apellido = table.Column<string>(type: "TEXT", nullable: false),
                    puesto = table.Column<string>(type: "TEXT", nullable: false),
                    sector = table.Column<string>(type: "TEXT", nullable: false),
                    EmpleadoId = table.Column<int>(type: "INTEGER", nullable: false),
                    Empleadosid = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Puestos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Puestos_Empleados_Empleadosid",
                        column: x => x.Empleadosid,
                        principalTable: "Empleados",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Puestos_Empleadosid",
                table: "Puestos",
                column: "Empleadosid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Puestos");

            migrationBuilder.DropTable(
                name: "Empleados");
        }
    }
}
