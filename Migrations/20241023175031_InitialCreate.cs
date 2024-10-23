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
                values: new object[] { "Admin", "1999000001", "Admin", true, "AQAAAAIAAYagAAAAEC6SeQu03ppZboEX3Z0rVE5WoEVyISvcGglV0ThEvDmtSkoEnyU9RZmNu40sMgqQ9w==" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Username", "Balance", "Course", "Discriminator", "Email", "FullName", "IsAdmin", "Password", "StudentId" },
                values: new object[] { "Mr_xl", 0m, "Computer Science", "Student", "mr_XL@example.com", "Abdulrahman Alkayail", false, "AQAAAAIAAYagAAAAEBZxK3DhhS40+3Ja746AT2CRCld3Sb6Xb/k2Aojban+8PvjHPgVH58K0PpTNmiFoBg==", "0000000000" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
