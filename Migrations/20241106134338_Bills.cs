using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mr_XL_Graduation.Migrations
{
    /// <inheritdoc />
    public partial class Bills : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Bills",
                table: "Users",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Username",
                keyValue: "Admin",
                column: "Password",
                value: "AQAAAAIAAYagAAAAEMCyXB1HsIrf3YFXtg+2XgjQNqI3hKZbzGwc9sEMLbYhmyEPmLo/CQiwmMzEd7XkLA==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Username",
                keyValue: "Mr_xl",
                columns: new[] { "Bills", "Password" },
                values: new object[] { 0m, "AQAAAAIAAYagAAAAEM/HrnkW0i3UkWrTTQpyzgRuJpuIEEI/f9l9WikTLsLmTVMZpz/798OAppo6aHMk9g==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bills",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Username",
                keyValue: "Admin",
                column: "Password",
                value: "AQAAAAIAAYagAAAAEC6SeQu03ppZboEX3Z0rVE5WoEVyISvcGglV0ThEvDmtSkoEnyU9RZmNu40sMgqQ9w==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Username",
                keyValue: "Mr_xl",
                column: "Password",
                value: "AQAAAAIAAYagAAAAEBZxK3DhhS40+3Ja746AT2CRCld3Sb6Xb/k2Aojban+8PvjHPgVH58K0PpTNmiFoBg==");
        }
    }
}
