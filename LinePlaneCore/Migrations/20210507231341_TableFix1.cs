using Microsoft.EntityFrameworkCore.Migrations;

namespace LinePlaneCore.Migrations
{
    public partial class TableFix1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Measurments_TipeFurnitures__IdFurniture",
                table: "Measurments");

            migrationBuilder.DropIndex(
                name: "IX_Measurments__IdFurniture",
                table: "Measurments");

            migrationBuilder.AlterColumn<string>(
                name: "_Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "_Width",
                table: "Measurments",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "_Length",
                table: "Measurments",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "_Password",
                table: "Users",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "_Width",
                table: "Measurments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "_Length",
                table: "Measurments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Measurments__IdFurniture",
                table: "Measurments",
                column: "_IdFurniture");

            migrationBuilder.AddForeignKey(
                name: "FK_Measurments_TipeFurnitures__IdFurniture",
                table: "Measurments",
                column: "_IdFurniture",
                principalTable: "TipeFurnitures",
                principalColumn: "_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
