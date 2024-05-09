using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rubiconmp.DA.Migrations
{
    /// <inheritdoc />
    public partial class AddIndexToRectangleModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Rectangles_X_Y",
                table: "Rectangles",
                columns: new[] { "X", "Y" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Rectangles_X_Y",
                table: "Rectangles");
        }
    }
}
