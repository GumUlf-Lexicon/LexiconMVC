using Microsoft.EntityFrameworkCore.Migrations;

namespace LexiconMVC.Migrations
{
    public partial class Reinit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    CountryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Population = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    CityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Population = table.Column<int>(nullable: false),
                    CountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.CityId);
                    table.ForeignKey(
                        name: "FK_City_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 32, nullable: false),
                    CityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_Person_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "CountryId", "Name", "Population" },
                values: new object[,]
                {
                    { 1, "Snowland", 643465 },
                    { 2, "Tingia", 9359342 },
                    { 3, "Portimien", 24465 },
                    { 4, "Vilmanie", 35419 }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "CityId", "CountryId", "Name", "Population" },
                values: new object[,]
                {
                    { 1, 1, "Hillville", 6231 },
                    { 4, 1, "Blackforest", 184 },
                    { 8, 1, "New Ironville", 1531 },
                    { 12, 1, "Silicone Mountain", 954 },
                    { 13, 1, "New Nessie City", 64564 },
                    { 14, 1, "Smalltown", 3401 },
                    { 2, 2, "Metropolis", 1583154 },
                    { 3, 2, "Atlantis", 2153 },
                    { 6, 2, "Cavetown", 15462 },
                    { 11, 2, "Spranley Hill", 8546 },
                    { 5, 3, "Woodlands", 7546 },
                    { 7, 3, "Castle Island", 29 },
                    { 9, 4, "Leppapolis", 14318 },
                    { 10, 4, "Blue Lake City", 98531 }
                });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "PersonId", "CityId", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, 1, "Anne Green", "555-6745-343" },
                    { 11, 1, "Kelly Flood", "555-1522-941" },
                    { 3, 4, "Chris Pillow", "555-6433-654" },
                    { 4, 4, "Diana Wald", "555-7436-445" },
                    { 10, 12, "Joanne Guidebird", "555-7256-434" },
                    { 2, 2, "Bob Woodyland", "555-4342-764" },
                    { 5, 2, "Erica Bobcat", "555-1272-237" },
                    { 7, 3, "Georgina Fiveling", "555-1392-865" },
                    { 9, 3, "Ivan Bow", "555-1010-001" },
                    { 12, 3, "Liam Baker", "555-4324-555" },
                    { 6, 11, "Fred Stone", "555-2383-278" },
                    { 8, 5, "Hank Red", "555-6547-378" },
                    { 13, 9, "Melly Greenfrog", "555-3831-197" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_City_CountryId",
                table: "City",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_CityId",
                table: "Person",
                column: "CityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
