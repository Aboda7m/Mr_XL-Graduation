using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mr_XL_Graduation.Migrations
{
    /// <inheritdoc />
    public partial class RemovedAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Course",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "Balance", "Course", "Email", "FullName" },
                values: new object[] { "0000000000", 0m, "Computer Science", "mr_XL@example.com", "abdulrahman alkayail" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Username", "IsAdmin", "Password", "StudentId" },
                values: new object[] { "Mr_xl", true, "AQAAAAIAAYagAAAAEF5k5xVuH3noQSLnM2LeoK+CzRcjAs1iYciwXZT39AYfUtOJQAU5T9vl5VnAhssgIg==", "0000000000" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Username",
                keyValue: "Mr_xl");

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: "0000000000");

            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Course",
                table: "Students");
        }
    }
}
