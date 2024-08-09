using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chapter3finalredone.Migrations
{
    /// <inheritdoc />
    public partial class adminrole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "7771b67e-bedb-45c7-8474-46e653d45b17", "71bb4cc7-866b-4a0a-81cb-cfe63e692f57" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2da23c92-b61b-4b1d-b612-c5a5653a7bf6", "761f8678-b33d-492f-a9e3-775c7a432d20" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8e48f6d7-87e7-4605-963a-c70629304ba9", "b64a988a-513e-4859-a160-be8b32ef00ea" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5ccb2d44-8c7a-4ff5-8bdf-f568115e049c", "58ebca9e-b7a7-4191-a46c-3dac0e670d13" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "36472483-93b4-4a0a-befd-4d8c36b18c18", "bbf7a5ca-7b63-4142-bf5e-a7652d6888d3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "7609304b-2084-4eb0-baf2-4ed6cbfc7164", "233541a8-a975-4e30-89b3-31b3ce5cd134" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1f76ed2c-4cc0-4af2-a58a-96ab14543721", "6530982a-de70-4a2a-9b56-db14615032e1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b04ba9c0-4256-4f9f-a182-89d86cac9abd", "4e379cef-9781-4a25-a303-e3840d14bd55" });
        }
    }
}
