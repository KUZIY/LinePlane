using Microsoft.EntityFrameworkCore.Migrations;

namespace LinePlaneCore.Migrations
{
    public partial class Tablecreat1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Сoordinates",
                columns: table => new
                {
                    _Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _X = table.Column<double>(type: "float", nullable: false),
                    _Y = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Сoordinates", x => x._Id);
                });

            migrationBuilder.CreateTable(
                name: "Measurments",
                columns: table => new
                {
                    _Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _Length = table.Column<int>(type: "int", nullable: false),
                    _Width = table.Column<int>(type: "int", nullable: false),
                    _IdFurniture = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measurments", x => x._Id);
                });

            migrationBuilder.CreateTable(
                name: "TipeFurnitures",
                columns: table => new
                {
                    _Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FurnitureTipe = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipeFurnitures", x => x._Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    _Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x._Id);
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
                    _FurnitureName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _FurnitureUSERName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _IdTipeFurniture = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Furnitures", x => x._Id);
                    table.ForeignKey(
                        name: "FK_Furnitures_TipeFurnitures__IdTipeFurniture",
                        column: x => x._IdTipeFurniture,
                        principalTable: "TipeFurnitures",
                        principalColumn: "_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Conservations",
                columns: table => new
                {
                    _Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _Picture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    _IdUser = table.Column<int>(type: "int", nullable: false),
                    _SaveName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conservations", x => x._Id);
                    table.ForeignKey(
                        name: "FK_Conservations_Users__IdUser",
                        column: x => x._IdUser,
                        principalTable: "Users",
                        principalColumn: "_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    _Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _IdConservation = table.Column<int>(type: "int", nullable: false),
                    _IdFurniture = table.Column<int>(type: "int", nullable: false),
                    _IdСoordinates = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x._Id);
                    table.ForeignKey(
                        name: "FK_Projects_Сoordinates__IdСoordinates",
                        column: x => x._IdСoordinates,
                        principalTable: "Сoordinates",
                        principalColumn: "_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projects_Conservations__IdConservation",
                        column: x => x._IdConservation,
                        principalTable: "Conservations",
                        principalColumn: "_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Walls",
                columns: table => new
                {
                    _Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _X1 = table.Column<double>(type: "float", nullable: false),
                    _Y1 = table.Column<double>(type: "float", nullable: false),
                    _X2 = table.Column<double>(type: "float", nullable: false),
                    _Y2 = table.Column<double>(type: "float", nullable: false),
                    _IdConservation = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Walls", x => x._Id);
                    table.ForeignKey(
                        name: "FK_Walls_Conservations__IdConservation",
                        column: x => x._IdConservation,
                        principalTable: "Conservations",
                        principalColumn: "_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Conservations__IdUser",
                table: "Conservations",
                column: "_IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Furnitures__IdTipeFurniture",
                table: "Furnitures",
                column: "_IdTipeFurniture");

            migrationBuilder.CreateIndex(
                name: "IX_Projects__IdСoordinates",
                table: "Projects",
                column: "_IdСoordinates");

            migrationBuilder.CreateIndex(
                name: "IX_Projects__IdConservation",
                table: "Projects",
                column: "_IdConservation");

            migrationBuilder.CreateIndex(
                name: "IX_Walls__IdConservation",
                table: "Walls",
                column: "_IdConservation");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Furnitures");

            migrationBuilder.DropTable(
                name: "Measurments");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Walls");

            migrationBuilder.DropTable(
                name: "TipeFurnitures");

            migrationBuilder.DropTable(
                name: "Сoordinates");

            migrationBuilder.DropTable(
                name: "Conservations");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
