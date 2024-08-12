using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrackersPROJ.Migrations
{
    /// <inheritdoc />
    public partial class nextfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Crackers_CrackersId",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "CrackerId",
                table: "Purchases");

            migrationBuilder.AlterColumn<int>(
                name: "CrackersId",
                table: "Purchases",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Crackers_CrackersId",
                table: "Purchases",
                column: "CrackersId",
                principalTable: "Crackers",
                principalColumn: "CrackersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Crackers_CrackersId",
                table: "Purchases");

            migrationBuilder.AlterColumn<int>(
                name: "CrackersId",
                table: "Purchases",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CrackerId",
                table: "Purchases",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Crackers_CrackersId",
                table: "Purchases",
                column: "CrackersId",
                principalTable: "Crackers",
                principalColumn: "CrackersId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
