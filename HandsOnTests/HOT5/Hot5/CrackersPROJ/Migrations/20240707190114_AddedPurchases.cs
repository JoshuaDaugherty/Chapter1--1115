using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrackersPROJ.Migrations
{
    /// <inheritdoc />
    public partial class AddedPurchases : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CrackerId = table.Column<int>(type: "int", nullable: false),
                    CrackersId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchases_Crackers_CrackersId",
                        column: x => x.CrackersId,
                        principalTable: "Crackers",
                        principalColumn: "CrackersId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Crackers",
                keyColumn: "CrackersId",
                keyValue: 1,
                column: "Price",
                value: "2.00");

            migrationBuilder.UpdateData(
                table: "Crackers",
                keyColumn: "CrackersId",
                keyValue: 2,
                column: "Price",
                value: "2.50");

            migrationBuilder.UpdateData(
                table: "Crackers",
                keyColumn: "CrackersId",
                keyValue: 3,
                column: "Price",
                value: "3.50");

            migrationBuilder.UpdateData(
                table: "Crackers",
                keyColumn: "CrackersId",
                keyValue: 4,
                column: "Price",
                value: "4.50");

            migrationBuilder.UpdateData(
                table: "Crackers",
                keyColumn: "CrackersId",
                keyValue: 5,
                column: "Price",
                value: "4.00");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_CrackersId",
                table: "Purchases",
                column: "CrackersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.UpdateData(
                table: "Crackers",
                keyColumn: "CrackersId",
                keyValue: 1,
                column: "Price",
                value: "$2.00");

            migrationBuilder.UpdateData(
                table: "Crackers",
                keyColumn: "CrackersId",
                keyValue: 2,
                column: "Price",
                value: "$4.00");

            migrationBuilder.UpdateData(
                table: "Crackers",
                keyColumn: "CrackersId",
                keyValue: 3,
                column: "Price",
                value: "$3.00");

            migrationBuilder.UpdateData(
                table: "Crackers",
                keyColumn: "CrackersId",
                keyValue: 4,
                column: "Price",
                value: "$4.50");

            migrationBuilder.UpdateData(
                table: "Crackers",
                keyColumn: "CrackersId",
                keyValue: 5,
                column: "Price",
                value: "$5.00");
        }
    }
}
