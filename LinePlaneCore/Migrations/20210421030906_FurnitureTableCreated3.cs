using Microsoft.EntityFrameworkCore.Migrations;

namespace LinePlaneCore.Migrations
{
    public partial class FurnitureTableCreated3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    _Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _NameRoom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x._Id);
                });

            migrationBuilder.CreateTable(
                name: "TipeFurnitures",
                columns: table => new
                {
                    _Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FurnitureTipeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipeFurnitures", x => x._Id);
                });

            migrationBuilder.CreateTable(
                name: "Furnitures",
                columns: table => new
                {
                    _Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _Picture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _Price = table.Column<int>(type: "int", nullable: false),
                    _IdRoom = table.Column<int>(type: "int", nullable: false),
                    _IdTipeFurniture = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Furnitures", x => x._Id);
                    table.ForeignKey(
                        name: "FK_Furnitures_Rooms__IdRoom",
                        column: x => x._IdRoom,
                        principalTable: "Rooms",
                        principalColumn: "_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Furnitures_TipeFurnitures__IdTipeFurniture",
                        column: x => x._IdTipeFurniture,
                        principalTable: "TipeFurnitures",
                        principalColumn: "_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Measurments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _Length = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _Width = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _IdFurniture = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measurments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Measurments_TipeFurnitures__IdFurniture",
                        column: x => x._IdFurniture,
                        principalTable: "TipeFurnitures",
                        principalColumn: "_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Furnitures__IdRoom",
                table: "Furnitures",
                column: "_IdRoom");

            migrationBuilder.CreateIndex(
                name: "IX_Furnitures__IdTipeFurniture",
                table: "Furnitures",
                column: "_IdTipeFurniture");

            migrationBuilder.CreateIndex(
                name: "IX_Measurments__IdFurniture",
                table: "Measurments",
                column: "_IdFurniture");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Furnitures");

            migrationBuilder.DropTable(
                name: "Measurments");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "TipeFurnitures");
        }
    }
}
