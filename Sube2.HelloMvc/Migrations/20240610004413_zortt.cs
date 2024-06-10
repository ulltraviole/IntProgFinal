using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sube2.HelloMvc.Migrations
{
    /// <inheritdoc />
    public partial class zortt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblDersler_tblOgrenciler_Ogrenciid",
                table: "tblDersler");

            migrationBuilder.DropIndex(
                name: "IX_tblDersler_Ogrenciid",
                table: "tblDersler");

            migrationBuilder.DropColumn(
                name: "SelectedDersId",
                table: "tblOgrenciler");

            migrationBuilder.DropColumn(
                name: "Ogrenciid",
                table: "tblDersler");

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

            migrationBuilder.AddColumn<int>(
                name: "SelectedDersId",
                table: "tblOgrenciler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Ogrenciid",
                table: "tblDersler",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblDersler_Ogrenciid",
                table: "tblDersler",
                column: "Ogrenciid");

            migrationBuilder.AddForeignKey(
                name: "FK_tblDersler_tblOgrenciler_Ogrenciid",
                table: "tblDersler",
                column: "Ogrenciid",
                principalTable: "tblOgrenciler",
                principalColumn: "Ogrenciid");
        }
    }
}
