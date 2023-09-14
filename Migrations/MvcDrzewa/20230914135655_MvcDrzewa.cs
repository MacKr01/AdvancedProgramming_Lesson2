using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdvancedProgramming_Lesson1.Migrations.MvcDrzewa
{
    public partial class MvcDrzewa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drzewa",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Wysokosc = table.Column<int>(nullable: false),
                    Rodzaj = table.Column<string>(nullable: true),
                    Data_posadzenia = table.Column<DateTime>(nullable: false),
                    Srednica_pnia = table.Column<int>(nullable: false),
                    Kolor_lisci = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drzewa", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drzewa");
        }
    }
}
