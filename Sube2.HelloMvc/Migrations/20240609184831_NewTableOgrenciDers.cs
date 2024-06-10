using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sube2.HelloMvc.Migrations
{
    /// <inheritdoc />
    public partial class NewTableOgrenciDers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblOgrenciDers",
                columns: table => new
                {
                    Ogrenciid = table.Column<int>(type: "int", nullable: false),
                    Dersid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblOgrenciDers");
        }
    }
}
