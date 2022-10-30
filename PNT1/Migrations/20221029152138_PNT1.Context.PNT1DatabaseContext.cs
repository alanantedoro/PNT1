using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PNT1.Migrations
{
    public partial class PNT1ContextPNT1DatabaseContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Titulo = table.Column<string>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true),
                    Valor = table.Column<double>(nullable: false),
                    Imagen = table.Column<string>(nullable: true),
                    Ubicacion = table.Column<string>(nullable: true),
                    FechaDeNacimiento = table.Column<DateTime>(nullable: false),
                    CategoriaTitulo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Titulo);
                    table.ForeignKey(
                        name: "FK_Item_Item_CategoriaTitulo",
                        column: x => x.CategoriaTitulo,
                        principalTable: "Item",
                        principalColumn: "Titulo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Username = table.Column<string>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Clave = table.Column<string>(nullable: true),
                    Edad = table.Column<int>(nullable: false),
                    FechaDeNacimiento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Username);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Item_CategoriaTitulo",
                table: "Item",
                column: "CategoriaTitulo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
