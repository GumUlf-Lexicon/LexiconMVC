using Microsoft.EntityFrameworkCore.Migrations;

namespace LexiconMVC.Migrations
{
    public partial class Polyglotts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PersonLanguage",
                keyColumns: new[] { "PersonId", "LanguageId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "PersonLanguage",
                keyColumns: new[] { "PersonId", "LanguageId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "PersonLanguage",
                keyColumns: new[] { "PersonId", "LanguageId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "PersonLanguage",
                keyColumns: new[] { "PersonId", "LanguageId" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                table: "PersonLanguage",
                keyColumns: new[] { "PersonId", "LanguageId" },
                keyValues: new object[] { 13, 2 });

            migrationBuilder.InsertData(
                table: "PersonLanguage",
                columns: new[] { "PersonId", "LanguageId" },
                values: new object[,]
                {
                    { 1, 5 },
                    { 12, 4 },
                    { 11, 9 },
                    { 11, 6 },
                    { 11, 3 },
                    { 10, 8 },
                    { 9, 8 },
                    { 9, 2 },
                    { 8, 5 },
                    { 7, 9 },
                    { 7, 7 },
                    { 7, 2 },
                    { 6, 5 },
                    { 6, 3 },
                    { 5, 10 },
                    { 5, 8 },
                    { 5, 6 },
                    { 5, 4 },
                    { 4, 3 },
                    { 2, 10 },
                    { 2, 1 },
                    { 1, 10 },
                    { 1, 9 },
                    { 1, 4 },
                    { 12, 10 },
                    { 13, 8 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PersonLanguage",
                keyColumns: new[] { "PersonId", "LanguageId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "PersonLanguage",
                keyColumns: new[] { "PersonId", "LanguageId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "PersonLanguage",
                keyColumns: new[] { "PersonId", "LanguageId" },
                keyValues: new object[] { 1, 9 });

            migrationBuilder.DeleteData(
                table: "PersonLanguage",
                keyColumns: new[] { "PersonId", "LanguageId" },
                keyValues: new object[] { 1, 10 });

            migrationBuilder.DeleteData(
                table: "PersonLanguage",
                keyColumns: new[] { "PersonId", "LanguageId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "PersonLanguage",
                keyColumns: new[] { "PersonId", "LanguageId" },
                keyValues: new object[] { 2, 10 });

            migrationBuilder.DeleteData(
                table: "PersonLanguage",
                keyColumns: new[] { "PersonId", "LanguageId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "PersonLanguage",
                keyColumns: new[] { "PersonId", "LanguageId" },
                keyValues: new object[] { 5, 4 });

            migrationBuilder.DeleteData(
                table: "PersonLanguage",
                keyColumns: new[] { "PersonId", "LanguageId" },
                keyValues: new object[] { 5, 6 });

            migrationBuilder.DeleteData(
                table: "PersonLanguage",
                keyColumns: new[] { "PersonId", "LanguageId" },
                keyValues: new object[] { 5, 8 });

            migrationBuilder.DeleteData(
                table: "PersonLanguage",
                keyColumns: new[] { "PersonId", "LanguageId" },
                keyValues: new object[] { 5, 10 });

            migrationBuilder.DeleteData(
                table: "PersonLanguage",
                keyColumns: new[] { "PersonId", "LanguageId" },
                keyValues: new object[] { 6, 3 });

            migrationBuilder.DeleteData(
                table: "PersonLanguage",
                keyColumns: new[] { "PersonId", "LanguageId" },
                keyValues: new object[] { 6, 5 });

            migrationBuilder.DeleteData(
                table: "PersonLanguage",
                keyColumns: new[] { "PersonId", "LanguageId" },
                keyValues: new object[] { 7, 2 });

            migrationBuilder.DeleteData(
                table: "PersonLanguage",
                keyColumns: new[] { "PersonId", "LanguageId" },
                keyValues: new object[] { 7, 7 });

            migrationBuilder.DeleteData(
                table: "PersonLanguage",
                keyColumns: new[] { "PersonId", "LanguageId" },
                keyValues: new object[] { 7, 9 });

            migrationBuilder.DeleteData(
                table: "PersonLanguage",
                keyColumns: new[] { "PersonId", "LanguageId" },
                keyValues: new object[] { 8, 5 });

            migrationBuilder.DeleteData(
                table: "PersonLanguage",
                keyColumns: new[] { "PersonId", "LanguageId" },
                keyValues: new object[] { 9, 2 });

            migrationBuilder.DeleteData(
                table: "PersonLanguage",
                keyColumns: new[] { "PersonId", "LanguageId" },
                keyValues: new object[] { 9, 8 });

            migrationBuilder.DeleteData(
                table: "PersonLanguage",
                keyColumns: new[] { "PersonId", "LanguageId" },
                keyValues: new object[] { 10, 8 });

            migrationBuilder.DeleteData(
                table: "PersonLanguage",
                keyColumns: new[] { "PersonId", "LanguageId" },
                keyValues: new object[] { 11, 3 });

            migrationBuilder.DeleteData(
                table: "PersonLanguage",
                keyColumns: new[] { "PersonId", "LanguageId" },
                keyValues: new object[] { 11, 6 });

            migrationBuilder.DeleteData(
                table: "PersonLanguage",
                keyColumns: new[] { "PersonId", "LanguageId" },
                keyValues: new object[] { 11, 9 });

            migrationBuilder.DeleteData(
                table: "PersonLanguage",
                keyColumns: new[] { "PersonId", "LanguageId" },
                keyValues: new object[] { 12, 4 });

            migrationBuilder.DeleteData(
                table: "PersonLanguage",
                keyColumns: new[] { "PersonId", "LanguageId" },
                keyValues: new object[] { 12, 10 });

            migrationBuilder.DeleteData(
                table: "PersonLanguage",
                keyColumns: new[] { "PersonId", "LanguageId" },
                keyValues: new object[] { 13, 8 });

            migrationBuilder.InsertData(
                table: "PersonLanguage",
                columns: new[] { "PersonId", "LanguageId" },
                values: new object[,]
                {
                    { 1, 3 },
                    { 1, 2 },
                    { 5, 1 },
                    { 13, 2 },
                    { 7, 1 }
                });
        }
    }
}
