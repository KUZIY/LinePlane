using Microsoft.EntityFrameworkCore.Migrations;

namespace LinePlaneCore.Migrations
{
    public partial class FurnitureTableCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Measurments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _Length = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _Width = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measurments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipeFurnitures",
                columns: table => new
                {
                    _Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FurnitureTipeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _IdFurniture = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipeFurnitures", x => x._Id);
                });

            migrationBuilder.CreateTable(
                name: "Furnitures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _Picture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _Price = table.Column<int>(type: "int", nullable: false),
                    _IdMeasurements = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Furnitures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Furnitures_Measurments__IdMeasurements",
                        column: x => x._IdMeasurements,
                        principalTable: "Measurments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    _Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _NameRoom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _IdTipeFurniture = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x._Id);
                    table.ForeignKey(
                        name: "FK_Rooms_TipeFurnitures__IdTipeFurniture",
                        column: x => x._IdTipeFurniture,
                        principalTable: "TipeFurnitures",
                        principalColumn: "_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Furnitures__IdMeasurements",
                table: "Furnitures",
                column: "_IdMeasurements");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms__IdTipeFurniture",
                table: "Rooms",
                column: "_IdTipeFurniture");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Furnitures");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Measurments");

            migrationBuilder.DropTable(
                name: "TipeFurnitures");
        }
    }
}
