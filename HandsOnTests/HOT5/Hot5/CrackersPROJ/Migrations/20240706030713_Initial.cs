using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CrackersPROJ.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Crackers",
                columns: table => new
                {
                    CrackersId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Invented = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Calories = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crackers", x => x.CrackersId);
                });

            migrationBuilder.InsertData(
                table: "Crackers",
                columns: new[] { "CrackersId", "Calories", "Invented", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 200, "1933", "Graham Crackers", "$2.00" },
                    { 2, 500, "1945", "Ritz", "$4.00" },
                    { 3, 300, "1950", "GoldFish", "$3.00" },
                    { 4, 400, "1960", "Saltine", "$4.50" },
                    { 5, 500, "1970", "Animal Crackers", "$5.00" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Crackers");
        }
    }
}
