using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SimpleMenu.Migrations
{
    /// <inheritdoc />
    public partial class initialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TblDish",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    imgUrl = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    price = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblDish", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TblIngredient",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblIngredient", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TblDishIngredient",
                columns: table => new
                {
                    dishId = table.Column<int>(type: "int", nullable: false),
                    ingredientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblDishIngredient", x => new { x.dishId, x.ingredientId });
                    table.ForeignKey(
                        name: "FK_TblDishIngredient_TblDish_dishId",
                        column: x => x.dishId,
                        principalTable: "TblDish",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblDishIngredient_TblIngredient_ingredientId",
                        column: x => x.ingredientId,
                        principalTable: "TblIngredient",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "TblDish",
                columns: new[] { "id", "imgUrl", "name", "price" },
                values: new object[] { 1, "https://i.pinimg.com/736x/6a/88/32/6a8832d29a911b320f9c68af86f8e134.jpg", "Pizza", 699.0 });

            migrationBuilder.InsertData(
                table: "TblIngredient",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Tomato Sauce" },
                    { 2, " Mozarella Cheese" },
                    { 3, "Pepperoni" }
                });

            migrationBuilder.InsertData(
                table: "TblDishIngredient",
                columns: new[] { "dishId", "ingredientId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblDishIngredient_ingredientId",
                table: "TblDishIngredient",
                column: "ingredientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblDishIngredient");

            migrationBuilder.DropTable(
                name: "TblDish");

            migrationBuilder.DropTable(
                name: "TblIngredient");
        }
    }
}
