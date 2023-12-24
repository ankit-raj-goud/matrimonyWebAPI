using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MatrimonyWebApi.Migrations
{
    /// <inheritdoc />
    public partial class donationTableAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Donations",
                columns: table => new
                {
                    DonationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DonerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    CityMasterCityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donations", x => x.DonationId);
                    table.ForeignKey(
                        name: "FK_Donations_CityMasters_CityMasterCityId",
                        column: x => x.CityMasterCityId,
                        principalTable: "CityMasters",
                        principalColumn: "CityId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Donations_CityMasterCityId",
                table: "Donations",
                column: "CityMasterCityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Donations");
        }
    }
}
