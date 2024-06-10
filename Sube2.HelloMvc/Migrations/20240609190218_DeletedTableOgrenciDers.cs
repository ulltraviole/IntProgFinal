using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sube2.HelloMvc.Migrations
{
    /// <inheritdoc />
    public partial class DeletedTableOgrenciDers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblOgrenciDers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblOgrenciDers",
                columns: table => new
                {
                    Dersid = table.Column<int>(type: "int", nullable: false),
                    Ogrenciid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });
        }
    }
}
