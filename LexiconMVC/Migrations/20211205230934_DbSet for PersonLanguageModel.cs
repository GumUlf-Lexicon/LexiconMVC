using Microsoft.EntityFrameworkCore.Migrations;

namespace LexiconMVC.Migrations
{
    public partial class DbSetforPersonLanguageModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonLanguageModel_Language_LanguageId",
                table: "PersonLanguageModel");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonLanguageModel_Person_PersonId",
                table: "PersonLanguageModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonLanguageModel",
                table: "PersonLanguageModel");

            migrationBuilder.RenameTable(
                name: "PersonLanguageModel",
                newName: "PersonLanguage");

            migrationBuilder.RenameIndex(
                name: "IX_PersonLanguageModel_LanguageId",
                table: "PersonLanguage",
                newName: "IX_PersonLanguage_LanguageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonLanguage",
                table: "PersonLanguage",
                columns: new[] { "PersonId", "LanguageId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PersonLanguage_Language_LanguageId",
                table: "PersonLanguage",
                column: "LanguageId",
                principalTable: "Language",
                principalColumn: "LanguageId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonLanguage_Person_PersonId",
                table: "PersonLanguage",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonLanguage_Language_LanguageId",
                table: "PersonLanguage");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonLanguage_Person_PersonId",
                table: "PersonLanguage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonLanguage",
                table: "PersonLanguage");

            migrationBuilder.RenameTable(
                name: "PersonLanguage",
                newName: "PersonLanguageModel");

            migrationBuilder.RenameIndex(
                name: "IX_PersonLanguage_LanguageId",
                table: "PersonLanguageModel",
                newName: "IX_PersonLanguageModel_LanguageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonLanguageModel",
                table: "PersonLanguageModel",
                columns: new[] { "PersonId", "LanguageId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PersonLanguageModel_Language_LanguageId",
                table: "PersonLanguageModel",
                column: "LanguageId",
                principalTable: "Language",
                principalColumn: "LanguageId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonLanguageModel_Person_PersonId",
                table: "PersonLanguageModel",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
