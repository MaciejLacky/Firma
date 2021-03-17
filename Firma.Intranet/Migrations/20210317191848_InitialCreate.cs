using Microsoft.EntityFrameworkCore.Migrations;

namespace Firma.Intranet.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aktualnosc",
                columns: table => new
                {
                    IdAktualnosci = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LinkTytul = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Tytul = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Tresc = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    Pozycja = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aktualnosc", x => x.IdAktualnosci);
                });

            migrationBuilder.CreateTable(
                name: "Strona",
                columns: table => new
                {
                    IdStrony = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LinkTytul = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Tytul = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Tresc = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    Pozycja = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Strona", x => x.IdStrony);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aktualnosc");

            migrationBuilder.DropTable(
                name: "Strona");
        }
    }
}
