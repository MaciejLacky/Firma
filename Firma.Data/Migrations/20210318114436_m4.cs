using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Firma.Data.Migrations
{
    public partial class m4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Zamowienie",
                columns: table => new
                {
                    IdZamowienia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataZamowienia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Imie = table.Column<string>(type: "nvarchar(160)", maxLength: 160, nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(160)", maxLength: 160, nullable: false),
                    Ulica = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Miasto = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Wojewodztwo = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    KodPocztowy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Panstwo = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    NumerTelefonu = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Razem = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zamowienie", x => x.IdZamowienia);
                });

            migrationBuilder.CreateTable(
                name: "PozycjaZamowienia",
                columns: table => new
                {
                    IdPozycjiZamowienia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ilosc = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cena = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdTowaru = table.Column<int>(type: "int", nullable: false),
                    TowarIdTowaru = table.Column<int>(type: "int", nullable: true),
                    IdZamowienia = table.Column<int>(type: "int", nullable: false),
                    ZamowienieIdZamowienia = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PozycjaZamowienia", x => x.IdPozycjiZamowienia);
                    table.ForeignKey(
                        name: "FK_PozycjaZamowienia_Towar_TowarIdTowaru",
                        column: x => x.TowarIdTowaru,
                        principalTable: "Towar",
                        principalColumn: "IdTowaru",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PozycjaZamowienia_Zamowienie_ZamowienieIdZamowienia",
                        column: x => x.ZamowienieIdZamowienia,
                        principalTable: "Zamowienie",
                        principalColumn: "IdZamowienia",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PozycjaZamowienia_TowarIdTowaru",
                table: "PozycjaZamowienia",
                column: "TowarIdTowaru");

            migrationBuilder.CreateIndex(
                name: "IX_PozycjaZamowienia_ZamowienieIdZamowienia",
                table: "PozycjaZamowienia",
                column: "ZamowienieIdZamowienia");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PozycjaZamowienia");

            migrationBuilder.DropTable(
                name: "Zamowienie");
        }
    }
}
