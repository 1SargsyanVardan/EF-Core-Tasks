using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleApp1.Migrations
{
    /// <inheritdoc />
    public partial class AddingCustomerId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "customerId",
                table: "callDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_callDetails_customerId",
                table: "callDetails",
                column: "customerId");

            migrationBuilder.AddForeignKey(
                name: "FK_callDetails_Customers_customerId",
                table: "callDetails",
                column: "customerId",
                principalTable: "Customers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_callDetails_Customers_customerId",
                table: "callDetails");

            migrationBuilder.DropIndex(
                name: "IX_callDetails_customerId",
                table: "callDetails");

            migrationBuilder.DropColumn(
                name: "customerId",
                table: "callDetails");
        }
    }
}
