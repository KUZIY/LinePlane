using Microsoft.EntityFrameworkCore.Migrations;

namespace LinePlaneCore.Migrations.User
{
    public partial class UserTableCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    _Login = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    _Password = table.Column<int>(type: "int", nullable: false),
                    _Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x._Login);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
