using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sube2.HelloMvc.Migrations
{
    /// <inheritdoc />
    public partial class FluentAPINew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DersOgrenci");

            migrationBuilder.CreateTable(
                name: "OgrenciDers",
                columns: table => new
                {
                    OgrenciId = table.Column<int>(type: "int", nullable: false),
                    DersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OgrenciDers", x => new { x.OgrenciId, x.DersId });
                    table.ForeignKey(
                        name: "FK_OgrenciDers_tblDersler_DersId",
                        column: x => x.DersId,
                        principalTable: "tblDersler",
                        principalColumn: "Dersid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OgrenciDers_tblOgrenciler_OgrenciId",
                        column: x => x.OgrenciId,
                        principalTable: "tblOgrenciler",
                        principalColumn: "Ogrenciid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OgrenciDers_DersId",
                table: "OgrenciDers",
                column: "DersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
