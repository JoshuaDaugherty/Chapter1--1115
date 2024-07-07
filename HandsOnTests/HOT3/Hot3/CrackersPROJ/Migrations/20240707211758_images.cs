using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrackersPROJ.Migrations
{
    /// <inheritdoc />
    public partial class images : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageFileName",
                table: "Crackers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Crackers",
                keyColumn: "CrackersId",
                keyValue: 1,
                column: "ImageFileName",
                value: "grahamCrackers.jpg");

            migrationBuilder.UpdateData(
                table: "Crackers",
                keyColumn: "CrackersId",
                keyValue: 2,
                column: "ImageFileName",
                value: "Ritz.jpg");

            migrationBuilder.UpdateData(
                table: "Crackers",
                keyColumn: "CrackersId",
                keyValue: 3,
                column: "ImageFileName",
                value: "GoldFish.jpg");

            migrationBuilder.UpdateData(
                table: "Crackers",
                keyColumn: "CrackersId",
                keyValue: 4,
                column: "ImageFileName",
                value: "Saltine.jpg");

            migrationBuilder.UpdateData(
                table: "Crackers",
                keyColumn: "CrackersId",
                keyValue: 5,
                column: "ImageFileName",
                value: "animal Crackers.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageFileName",
                table: "Crackers");
        }
    }
}
