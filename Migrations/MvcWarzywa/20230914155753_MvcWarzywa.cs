using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdvancedProgramming_Lesson1.Migrations.MvcWarzywa
{
    public partial class MvcWarzywa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Warzywa",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Typ_warzywa = table.Column<string>(nullable: true),
                    Data_siewu = table.Column<DateTime>(nullable: false),
                    Data_zbioru = table.Column<DateTime>(nullable: false),
                    Waga = table.Column<int>(nullable: false),
                    Cena = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warzywa", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Warzywa");
        }
    }
}
