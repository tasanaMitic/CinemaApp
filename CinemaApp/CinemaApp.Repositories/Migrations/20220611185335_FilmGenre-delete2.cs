using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaApp.Repositories.Migrations
{
    public partial class FilmGenredelete2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmGenres");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FilmGenres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    FilmId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmGenres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FilmGenres_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "FilmGenres",
                columns: new[] { "Id", "FilmId", "Name" },
                values: new object[,]
                {
                    { 0, null, "HORROR" },
                    { 1, null, "COMEDY" },
                    { 2, null, "DRAMA" },
                    { 3, null, "THRILLER" },
                    { 4, null, "ROMANCE" },
                    { 5, null, "DOCUMENTARY" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilmGenres_FilmId",
                table: "FilmGenres",
                column: "FilmId");
        }
    }
}
