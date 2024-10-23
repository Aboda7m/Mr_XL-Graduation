using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mr_XL_Graduation.Migrations
{
    /// <inheritdoc />
    public partial class UpdateStudentSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "Username", "Password", "StudentId" },
                values: new object[] { "Mr_xl", "pass123", "0000000000" });
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
                name: "Course",
                table: "Students");
        }
    }
}
