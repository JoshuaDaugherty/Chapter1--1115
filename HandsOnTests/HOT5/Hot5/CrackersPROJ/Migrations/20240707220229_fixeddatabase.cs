using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrackersPROJ.Migrations
{
    /// <inheritdoc />
    public partial class fixeddatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Crackers",
                keyColumn: "CrackersId",
                keyValue: 1,
                columns: new[] { "Calories", "Price" },
                values: new object[] { 20, "$2.00" });

            migrationBuilder.UpdateData(
                table: "Crackers",
                keyColumn: "CrackersId",
                keyValue: 2,
                columns: new[] { "Calories", "Price" },
                values: new object[] { 25, "$2.50" });

            migrationBuilder.UpdateData(
                table: "Crackers",
                keyColumn: "CrackersId",
                keyValue: 3,
                columns: new[] { "Calories", "Price" },
                values: new object[] { 15, "$3.50" });

            migrationBuilder.UpdateData(
                table: "Crackers",
                keyColumn: "CrackersId",
                keyValue: 4,
                columns: new[] { "Calories", "Price" },
                values: new object[] { 8, "$4.50" });

            migrationBuilder.UpdateData(
                table: "Crackers",
                keyColumn: "CrackersId",
                keyValue: 5,
                columns: new[] { "Calories", "Price" },
                values: new object[] { 7, "$4.00" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Crackers",
                keyColumn: "CrackersId",
                keyValue: 1,
                columns: new[] { "Calories", "Price" },
                values: new object[] { 200, "2.00" });

            migrationBuilder.UpdateData(
                table: "Crackers",
                keyColumn: "CrackersId",
                keyValue: 2,
                columns: new[] { "Calories", "Price" },
                values: new object[] { 500, "2.50" });

            migrationBuilder.UpdateData(
                table: "Crackers",
                keyColumn: "CrackersId",
                keyValue: 3,
                columns: new[] { "Calories", "Price" },
                values: new object[] { 300, "3.50" });

            migrationBuilder.UpdateData(
                table: "Crackers",
                keyColumn: "CrackersId",
                keyValue: 4,
                columns: new[] { "Calories", "Price" },
                values: new object[] { 400, "4.50" });

            migrationBuilder.UpdateData(
                table: "Crackers",
                keyColumn: "CrackersId",
                keyValue: 5,
                columns: new[] { "Calories", "Price" },
                values: new object[] { 500, "4.00" });
        }
    }
}
