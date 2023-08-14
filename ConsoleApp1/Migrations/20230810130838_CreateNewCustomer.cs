using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleApp1.Migrations
{
    /// <inheritdoc />
    public partial class CreateNewCustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NewCustomerId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "newCustomer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_newCustomer", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_NewCustomerId",
                table: "Orders",
                column: "NewCustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_newCustomer_NewCustomerId",
                table: "Orders",
                column: "NewCustomerId",
                principalTable: "newCustomer",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_newCustomer_NewCustomerId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "newCustomer");

            migrationBuilder.DropIndex(
                name: "IX_Orders_NewCustomerId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "NewCustomerId",
                table: "Orders");
        }
    }
}
