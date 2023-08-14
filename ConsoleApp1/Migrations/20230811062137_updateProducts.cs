using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleApp1.Migrations
{
    /// <inheritdoc />
    public partial class updateProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bestSellerProducts_Details_DetailsId",
                table: "bestSellerProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_features_Details_DetailsId",
                table: "features");

            migrationBuilder.DropForeignKey(
                name: "FK_productOrders_bestSellerProducts_BestSellerProductsId",
                table: "productOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_productOrders_features_FeaturedProductsId",
                table: "productOrders");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Product_Quantity2",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_productOrders_BestSellerProductsId",
                table: "productOrders");

            migrationBuilder.DropIndex(
                name: "IX_productOrders_FeaturedProductsId",
                table: "productOrders");

            migrationBuilder.DropIndex(
                name: "IX_features_DetailsId",
                table: "features");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Product_Quantity1",
                table: "features");

            migrationBuilder.DropIndex(
                name: "IX_bestSellerProducts_DetailsId",
                table: "bestSellerProducts");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Product_Quantity",
                table: "bestSellerProducts");

            migrationBuilder.DropColumn(
                name: "BestSellerProductsId",
                table: "productOrders");

            migrationBuilder.DropColumn(
                name: "FeaturedProductsId",
                table: "productOrders");

            migrationBuilder.DropColumn(
                name: "DetailsId",
                table: "features");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "features");

            migrationBuilder.DropColumn(
                name: "StockQuantity",
                table: "features");

            migrationBuilder.DropColumn(
                name: "DetailsId",
                table: "bestSellerProducts");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "bestSellerProducts");

            migrationBuilder.DropColumn(
                name: "StockQuantity",
                table: "bestSellerProducts");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Product_Quantity",
                table: "Products",
                sql: "[StockQuantity]>0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "DetailsId",
                table: "features",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "features",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StockQuantity",
                table: "features",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DetailsId",
                table: "bestSellerProducts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "bestSellerProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StockQuantity",
                table: "bestSellerProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                name: "IX_features_DetailsId",
                table: "features",
                column: "DetailsId");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Product_Quantity1",
                table: "features",
                sql: "[StockQuantity]>0");

            migrationBuilder.CreateIndex(
                name: "IX_bestSellerProducts_DetailsId",
                table: "bestSellerProducts",
                column: "DetailsId");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Product_Quantity",
                table: "bestSellerProducts",
                sql: "[StockQuantity]>0");

            migrationBuilder.AddForeignKey(
                name: "FK_bestSellerProducts_Details_DetailsId",
                table: "bestSellerProducts",
                column: "DetailsId",
                principalTable: "Details",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_features_Details_DetailsId",
                table: "features",
                column: "DetailsId",
                principalTable: "Details",
                principalColumn: "Id");

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
    }
}
