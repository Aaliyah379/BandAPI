using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BandAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bands",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Founded = table.Column<DateTime>(nullable: false),
                    MainGenre = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(maxLength: 200, nullable: false),
                    Description = table.Column<string>(maxLength: 400, nullable: true),
                    BandId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Albums_Bands_BandId",
                        column: x => x.BandId,
                        principalTable: "Bands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Bands",
                columns: new[] { "Id", "Founded", "MainGenre", "Name" },
                values: new object[,]
                {
                    { new Guid("0fe4776c-dfff-4134-aa03-2b7e31558186"), new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Heavy Metall", "Metallica" },
                    { new Guid("926f664c-930b-49f3-95a0-a4bf241b6c6c"), new DateTime(1985, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rock", "Guns N Roses" },
                    { new Guid("3c0da630-dc17-4898-afd4-bbe71f5bb26d"), new DateTime(1965, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Disco", "ABBA" },
                    { new Guid("a024e32a-bda3-404f-8c82-a510a37e67c2"), new DateTime(1991, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alternative", "Oasis" },
                    { new Guid("5bdb346e-1f26-41be-a7e3-254a4d2a34f4"), new DateTime(1981, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pop", "A-ha" }
                });

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "Id", "BandId", "Description", "Title" },
                values: new object[,]
                {
                    { new Guid("bf3b11e9-ee82-4ccb-8e9e-5efd82652880"), new Guid("0fe4776c-dfff-4134-aa03-2b7e31558186"), "One of the best albums ever", "Master of Pappets" },
                    { new Guid("b36c8190-2c9a-4e07-817b-ff767d03e856"), new Guid("926f664c-930b-49f3-95a0-a4bf241b6c6c"), "Amazing Rock album with a raw sound", "Appetite for Destruction" },
                    { new Guid("ce41e436-1373-4fdb-9aa3-02759d4a0c63"), new Guid("3c0da630-dc17-4898-afd4-bbe71f5bb26d"), "Very groovy sound", "Waterloo" },
                    { new Guid("94c0e8ac-253c-43c7-9ef9-979d1ecb359e"), new Guid("a024e32a-bda3-404f-8c82-a510a37e67c2"), "Arguably one of the best albums by Oasis", "Be here now" },
                    { new Guid("c4d67114-ec33-494f-a5fc-c85db4dadd05"), new Guid("5bdb346e-1f26-41be-a7e3-254a4d2a34f4"), "Awesome debut album by A-ha", "Hunting Hight and Low" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Albums_BandId",
                table: "Albums",
                column: "BandId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "Bands");
        }
    }
}
