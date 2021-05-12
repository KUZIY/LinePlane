using Microsoft.EntityFrameworkCore.Migrations;

namespace LinePlaneCore.Migrations
{
    public partial class TableFix2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "_Angle",
                table: "Сoordinates",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "_Angle",
                table: "Сoordinates");
        }
    }
}
