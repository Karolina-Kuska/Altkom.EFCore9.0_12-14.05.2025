using DAL.Properties;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddStoredProcedure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*migrationBuilder.Sql(@"
                CREATE OR ALTER PROCEDURE GetUserByType @TYPE nvarchar(max)
                AS
                BEGIN
                    SELECT * FROM [User]
                    WHERE UserType = @TYPE
                END");*/
            migrationBuilder.Sql(Resources.GetUserByType_UP);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.Sql(@"DROP PROCEDURE IF EXISTS GetUserByType");
            migrationBuilder.Sql(Resources.GetUserByType_DOWN);
        }
    }
}
