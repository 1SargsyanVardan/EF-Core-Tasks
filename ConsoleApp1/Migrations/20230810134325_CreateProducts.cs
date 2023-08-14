using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleApp1.Migrations
{
    /// <inheritdoc />
    public partial class CreateProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Product_Quantity",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "BestSellerProductsId",
                table: "productOrders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FeaturedProductsId",
                table: "productOrders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "bestSellerProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    DetailsId = table.Column<int>(type: "int", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bestSellerProducts", x => x.Id);
                    table.CheckConstraint("CK_Product_Quantity", "[StockQuantity]>0");
                    table.ForeignKey(
                        name: "FK_bestSellerProducts_Details_DetailsId",
                        column: x => x.DetailsId,
                        principalTable: "Details",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "features",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    DetailsId = table.Column<int>(type: "int", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_features", x => x.Id);
                    table.CheckConstraint("CK_Product_Quantity1", "[StockQuantity]>0");
                    table.ForeignKey(
                        name: "FK_features_Details_DetailsId",
                        column: x => x.DetailsId,
                        principalTable: "Details",
                        principalColumn: "Id");
                });

            migrationBuilder.AddCheckConstraint(
                name: "CK_Product_Quantity2",
                table: "Products",
                sql: "[StockQuantity]>0");

            migrationBuilder.CreateIndex(
                name: "IX_productOrders_BestSellerProductsId",
                table: "productOrders",
                column: "BestSellerProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_productOrders_FeaturedProductsId",
                table: "productOrders",
                column: "FeaturedProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_bestSellerProducts_DetailsId",
                table: "bestSellerProducts",
                column: "DetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_features_DetailsId",
                table: "features",
                column: "DetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_productOrders_bestSellerProducts_BestSellerProductsId",
                table: "productOrders",
                column: "BestSellerProductsId",
                principalTable: "bestSellerProducts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_productOrders_features_FeaturedProductsId",
                table: "productOrders",
                column: "FeaturedProductsId",
                principalTable: "features",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_productOrders_bestSellerProducts_BestSellerProductsId",
                table: "productOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_productOrders_features_FeaturedProductsId",
                table: "productOrders");

            migrationBuilder.DropTable(
                name: "bestSellerProducts");

            migrationBuilder.DropTable(
                name: "features");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Product_Quantity2",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_productOrders_BestSellerProductsId",
                table: "productOrders");

            migrationBuilder.DropIndex(
                name: "IX_productOrders_FeaturedProductsId",
                table: "productOrders");

            migrationBuilder.DropColumn(
                name: "BestSellerProductsId",
                table: "productOrders");

            migrationBuilder.DropColumn(
                name: "FeaturedProductsId",
                table: "productOrders");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Product_Quantity",
                table: "Products",
                sql: "[StockQuantity]>0");
        }
    }
}
