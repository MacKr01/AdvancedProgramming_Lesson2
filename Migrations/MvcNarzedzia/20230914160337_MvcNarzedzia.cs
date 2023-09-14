using Microsoft.EntityFrameworkCore.Migrations;

namespace AdvancedProgramming_Lesson1.Migrations.MvcNarzedzia
{
    public partial class MvcNarzedzia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Narzedzia",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Typ_narzedzia = table.Column<string>(nullable: true),
                    Material_wykonania = table.Column<string>(nullable: true),
                    Waga = table.Column<int>(nullable: false),
                    Dlugosc = table.Column<int>(nullable: false),
                    Cena = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Narzedzia", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Narzedzia");
        }
    }
}
