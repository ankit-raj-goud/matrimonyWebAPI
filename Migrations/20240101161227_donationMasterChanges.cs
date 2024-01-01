using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MatrimonyWebApi.Migrations
{
    /// <inheritdoc />
    public partial class donationMasterChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donations_CityMasters_CityMasterCityId",
                table: "Donations");

            migrationBuilder.DropIndex(
                name: "IX_Donations_CityMasterCityId",
                table: "Donations");

            migrationBuilder.DropColumn(
                name: "CityMasterCityId",
                table: "Donations");

            migrationBuilder.RenameColumn(
                name: "CityId",
                table: "Donations",
                newName: "CityIdRef");

            migrationBuilder.CreateIndex(
                name: "IX_Donations_CityIdRef",
                table: "Donations",
                column: "CityIdRef");

            migrationBuilder.AddForeignKey(
                name: "FK_Donations_CityMasters_CityIdRef",
                table: "Donations",
                column: "CityIdRef",
                principalTable: "CityMasters",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donations_CityMasters_CityIdRef",
                table: "Donations");

            migrationBuilder.DropIndex(
                name: "IX_Donations_CityIdRef",
                table: "Donations");

            migrationBuilder.RenameColumn(
                name: "CityIdRef",
                table: "Donations",
                newName: "CityId");

            migrationBuilder.AddColumn<int>(
                name: "CityMasterCityId",
                table: "Donations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Donations_CityMasterCityId",
                table: "Donations",
                column: "CityMasterCityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Donations_CityMasters_CityMasterCityId",
                table: "Donations",
                column: "CityMasterCityId",
                principalTable: "CityMasters",
                principalColumn: "CityId");
        }
    }
}
