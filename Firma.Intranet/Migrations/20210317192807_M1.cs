using Microsoft.EntityFrameworkCore.Migrations;

namespace Firma.Intranet.Migrations
{
    public partial class M1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rodzaj",
                columns: table => new
                {
                    IdRodzaju = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rodzaj", x => x.IdRodzaju);
                });

            migrationBuilder.CreateTable(
                name: "Towar",
                columns: table => new
                {
                    IdTowaru = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cena = table.Column<decimal>(type: "money", nullable: false),
                    FotoURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdRodzaju = table.Column<int>(type: "int", nullable: false),
                    RodzajIdRodzaju = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Towar", x => x.IdTowaru);
                    table.ForeignKey(
                        name: "FK_Towar_Rodzaj_RodzajIdRodzaju",
                        column: x => x.RodzajIdRodzaju,
                        principalTable: "Rodzaj",
                        principalColumn: "IdRodzaju",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Towar_RodzajIdRodzaju",
                table: "Towar",
                column: "RodzajIdRodzaju");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Towar");

            migrationBuilder.DropTable(
                name: "Rodzaj");
        }
    }
}
