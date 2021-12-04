using Microsoft.EntityFrameworkCore.Migrations;

namespace LexiconMVC.Migrations
{
    public partial class Seedingdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonId", "City", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Hillville", "Anne Green", "555-6745-343" },
                    { 2, "Metropolis", "Bob Woodyland", "555-4342-764" },
                    { 3, "Atlantis", "Chris Pillow", "555-6433-654" },
                    { 4, "Blackforest", "Diana Wald", "555-7436-445" },
                    { 5, "Woodlands", "Erica Bobcat", "555-1272-237" },
                    { 6, "Cavetown", "Fred Stone", "555-2383-278" },
                    { 7, "Castle Island", "Georgina Fiveling", "555-1392-865" },
                    { 8, "New Ironville", "Hank Red", "555-6547-378" },
                    { 9, "Leppapolis", "Ivan Bow", "555-1010-001" },
                    { 10, "Blue Lake", "Joanne Guidebird", "555-7256-434" },
                    { 11, "Spranley Hill", "Kelly Flood", "555-1522-941" },
                    { 12, "Silicone Mountain", "Liam Baker", "555-4324-555" },
                    { 13, "New Nessie City", "Melly Greenfrog", "555-3831-197" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 13);
        }
    }
}
