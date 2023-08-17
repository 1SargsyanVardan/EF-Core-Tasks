using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleApp1.Migrations
{
    /// <inheritdoc />
    public partial class AddFirstFunction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           /* migrationBuilder.Sql(@"CREATE FUNCTION [dbo].[GetAge]
                                (
	                                @param Date
                                )
                                RETURNS INT
                                AS
                                BEGIN
	                                declare @age int;
	                                set @age = DATEDIFF(year,@param,GETDATE()) -
			                                   IIF(DATEADD(YEAR, DATEDIFF(YEAR, @param,GETDATE()), @param) > GETDATE(), 1, 0)
	                                RETURN @age
                                END
                                ");*/
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
