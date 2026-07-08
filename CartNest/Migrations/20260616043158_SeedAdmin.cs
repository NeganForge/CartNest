using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CartNest.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$AoIknFWBuLHhIbA/DJCDIeDDXZ4K2qguOEbSGEvdfzsKA28l1eVXi");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$2QpWDRokQwbpPbYWGi4CLu//LPPna4EnuhPzxq3oC37EtbbKFRVeG");
        }
    }
}
