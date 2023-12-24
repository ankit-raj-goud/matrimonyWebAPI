using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MatrimonyWebApi.Migrations
{
    /// <inheritdoc />
    public partial class dbChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StateMasters_Country_CountryCoutnryId",
                table: "StateMasters");

            migrationBuilder.RenameColumn(
                name: "CountryCoutnryId",
                table: "StateMasters",
                newName: "CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_StateMasters_CountryCoutnryId",
                table: "StateMasters",
                newName: "IX_StateMasters_CountryId");

            migrationBuilder.RenameColumn(
                name: "CoutnryId",
                table: "Country",
                newName: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_StateMasters_Country_CountryId",
                table: "StateMasters",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StateMasters_Country_CountryId",
                table: "StateMasters");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "StateMasters",
                newName: "CountryCoutnryId");

            migrationBuilder.RenameIndex(
                name: "IX_StateMasters_CountryId",
                table: "StateMasters",
                newName: "IX_StateMasters_CountryCoutnryId");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "Country",
                newName: "CoutnryId");

            migrationBuilder.AddForeignKey(
                name: "FK_StateMasters_Country_CountryCoutnryId",
                table: "StateMasters",
                column: "CountryCoutnryId",
                principalTable: "Country",
                principalColumn: "CoutnryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
