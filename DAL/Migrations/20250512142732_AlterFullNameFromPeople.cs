using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class AlterFullNameFromPeople : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "People",
                type: "nvarchar(max)",
                nullable: false,
                computedColumnSql: "CONCAT(FirstName, ' ', LastName)",
                stored: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComputedColumnSql: "CONCAT(FirstName, ' ', LastName)",
                oldStored: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "People",
                type: "nvarchar(max)",
                nullable: false,
                computedColumnSql: "CONCAT(FirstName, ' ', LastName)",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComputedColumnSql: "CONCAT(FirstName, ' ', LastName)");
        }
    }
}
