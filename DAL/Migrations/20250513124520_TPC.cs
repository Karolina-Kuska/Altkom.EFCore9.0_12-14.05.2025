using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class TPC : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "AnimalSequence");

            migrationBuilder.CreateTable(
                name: "Animal",
                columns: table => new
                {
                    Key = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [AnimalSequence]"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Species = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animal", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "Cat",
                columns: table => new
                {
                    Key = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [AnimalSequence]"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Species = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cat", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "Dog",
                columns: table => new
                {
                    Key = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [AnimalSequence]"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Species = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Breed = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dog", x => x.Key);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animal");

            migrationBuilder.DropTable(
                name: "Cat");

            migrationBuilder.DropTable(
                name: "Dog");

            migrationBuilder.DropSequence(
                name: "AnimalSequence");
        }
    }
}
