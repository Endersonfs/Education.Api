using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Education.Persistence.Migrations
{
    public partial class EducationMigrationInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    CursoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FechaPublicacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(14,2)", precision: 14, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.CursoId);
                });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "CursoId", "Descripcion", "FechaCreacion", "FechaPublicacion", "Precio", "Titulo" },
                values: new object[] { new Guid("d3ca4bbf-e6a1-4849-aa00-05fda455e1ed"), "Curso de c# basico", new DateTime(2021, 8, 30, 17, 11, 25, 722, DateTimeKind.Local).AddTicks(3430), new DateTime(2023, 8, 30, 17, 11, 25, 726, DateTimeKind.Local).AddTicks(4426), 56m, "C# desde cero hasta avanzado" });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "CursoId", "Descripcion", "FechaCreacion", "FechaPublicacion", "Precio", "Titulo" },
                values: new object[] { new Guid("07213f91-815f-4ffb-927d-e2cc0e7ff366"), "Curso de Java", new DateTime(2021, 8, 30, 17, 11, 25, 729, DateTimeKind.Local).AddTicks(281), new DateTime(2023, 8, 30, 17, 11, 25, 729, DateTimeKind.Local).AddTicks(306), 25m, "Master en Java Spring desde las raices" });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "CursoId", "Descripcion", "FechaCreacion", "FechaPublicacion", "Precio", "Titulo" },
                values: new object[] { new Guid("247b54d0-7e19-44b8-8de6-cb5e627b662f"), "Curso de Unit Test para NET Core", new DateTime(2021, 8, 30, 17, 11, 25, 729, DateTimeKind.Local).AddTicks(428), new DateTime(2023, 8, 30, 17, 11, 25, 729, DateTimeKind.Local).AddTicks(577), 1000m, "Master en UNIT Test con CQRS" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cursos");
        }
    }
}
