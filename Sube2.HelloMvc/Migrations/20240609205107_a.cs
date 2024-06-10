using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sube2.HelloMvc.Migrations
{
    /// <inheritdoc />
    public partial class a : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OgrenciDers");

            migrationBuilder.CreateTable(
                name: "DersOgrenci",
                columns: table => new
                {
                    DerslerDersid = table.Column<int>(type: "int", nullable: false),
                    OgrencilerOgrenciid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DersOgrenci", x => new { x.DerslerDersid, x.OgrencilerOgrenciid });
                    table.ForeignKey(
                        name: "FK_DersOgrenci_tblDersler_DerslerDersid",
                        column: x => x.DerslerDersid,
                        principalTable: "tblDersler",
                        principalColumn: "Dersid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DersOgrenci_tblOgrenciler_OgrencilerOgrenciid",
                        column: x => x.OgrencilerOgrenciid,
                        principalTable: "tblOgrenciler",
                        principalColumn: "Ogrenciid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DersOgrenci_OgrencilerOgrenciid",
                table: "DersOgrenci",
                column: "OgrencilerOgrenciid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DersOgrenci");

            migrationBuilder.CreateTable(
                name: "OgrenciDers",
                columns: table => new
                {
                    Ogrenciid = table.Column<int>(type: "int", nullable: false),
                    Dersid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OgrenciDers", x => new { x.Ogrenciid, x.Dersid });
                    table.ForeignKey(
                        name: "FK_OgrenciDers_tblDersler_Dersid",
                        column: x => x.Dersid,
                        principalTable: "tblDersler",
                        principalColumn: "Dersid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OgrenciDers_tblOgrenciler_Ogrenciid",
                        column: x => x.Ogrenciid,
                        principalTable: "tblOgrenciler",
                        principalColumn: "Ogrenciid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OgrenciDers_Dersid",
                table: "OgrenciDers",
                column: "Dersid");
        }
    }
}
