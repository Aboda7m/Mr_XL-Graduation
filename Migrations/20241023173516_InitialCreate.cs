using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mr_XL_Graduation.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    AdminId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Course = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Username);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Username", "AdminId", "Discriminator", "IsAdmin", "Password" },
                values: new object[] { "Admin", "1999000001", "Admin", true, "AQAAAAIAAYagAAAAEArwNtgxhOuMd8+jFurQb1fODJRe2PS6w09B2nsgtexlU62p5RfIvuxkCVFGFqLfNg==" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Username", "Balance", "Course", "Discriminator", "Email", "FullName", "IsAdmin", "Password", "StudentId" },
                values: new object[] { "Mr_xl", 0m, "Computer Science", "Student", "mr_XL@example.com", "Abdulrahman Alkayail", false, "AQAAAAIAAYagAAAAEP1qFMKAvnjdbD+BzPNlFRXf42PO38gbCmsO99yQwEjurvTlGyorI6yBbTKti5uu7w==", "0000000000" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
