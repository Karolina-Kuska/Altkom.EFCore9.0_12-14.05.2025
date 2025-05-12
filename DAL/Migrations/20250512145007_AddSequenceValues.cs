using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddSequenceValues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "CustomId");

            migrationBuilder.CreateSequence<int>(
                name: "MySequence",
                startValue: 150L,
                incrementBy: 22,
                minValue: 100L,
                maxValue: 200L,
                cyclic: true);

            migrationBuilder.CreateTable(
                name: "SequenceValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR CustomId"),
                    Value = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR MySequence"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SequenceValues", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SequenceValues");

            migrationBuilder.DropSequence(
                name: "CustomId");

            migrationBuilder.DropSequence(
                name: "MySequence");
        }
    }
}
