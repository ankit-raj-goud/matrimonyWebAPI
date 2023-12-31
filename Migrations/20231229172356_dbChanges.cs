using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MatrimonyWebApi.Migrations
{
    /// <inheritdoc />
    public partial class dbChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminMasters",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminMasters", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "GenderMasters",
                columns: table => new
                {
                    GenderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenderMasters", x => x.GenderId);
                });

            migrationBuilder.CreateTable(
                name: "InterestStatusMasters",
                columns: table => new
                {
                    InterestStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InterestStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterestStatusMasters", x => x.InterestStatusId);
                });

            migrationBuilder.CreateTable(
                name: "MaritialStatusMasters",
                columns: table => new
                {
                    MaritialStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaritialStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaritialStatusMasters", x => x.MaritialStatusId);
                });

            migrationBuilder.CreateTable(
                name: "ReligionMasters",
                columns: table => new
                {
                    ReligionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReligionName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReligionMasters", x => x.ReligionId);
                });

            migrationBuilder.CreateTable(
                name: "StateMasters",
                columns: table => new
                {
                    StateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryIdRef = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateMasters", x => x.StateId);
                    table.ForeignKey(
                        name: "FK_StateMasters_Country_CountryIdRef",
                        column: x => x.CountryIdRef,
                        principalTable: "Country",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CasteMasters",
                columns: table => new
                {
                    CasteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CasteName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReligionIdRef = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CasteMasters", x => x.CasteId);
                    table.ForeignKey(
                        name: "FK_CasteMasters_ReligionMasters_ReligionIdRef",
                        column: x => x.ReligionIdRef,
                        principalTable: "ReligionMasters",
                        principalColumn: "ReligionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CityMasters",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateIdRef = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityMasters", x => x.CityId);
                    table.ForeignKey(
                        name: "FK_CityMasters_StateMasters_StateIdRef",
                        column: x => x.StateIdRef,
                        principalTable: "StateMasters",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "AdminMasters",
                columns: new[] { "UserId", "Password", "UserName" },
                values: new object[] { new Guid("dd467971-80d6-43a6-a1ab-8b64cd25dedd"), "admin", "admin" });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "CountryId", "CountryName" },
                values: new object[] { 1, "India" });

            migrationBuilder.InsertData(
                table: "GenderMasters",
                columns: new[] { "GenderId", "Gender" },
                values: new object[,]
                {
                    { 1, "Male" },
                    { 2, "Female" },
                    { 3, "Other" }
                });

            migrationBuilder.InsertData(
                table: "InterestStatusMasters",
                columns: new[] { "InterestStatusId", "InterestStatus" },
                values: new object[,]
                {
                    { 1, "Open" },
                    { 2, "Accepted" },
                    { 3, "Rejected" }
                });

            migrationBuilder.InsertData(
                table: "MaritialStatusMasters",
                columns: new[] { "MaritialStatusId", "MaritialStatus" },
                values: new object[,]
                {
                    { 1, "Unmarried" },
                    { 2, "Widow" },
                    { 3, "Divorced" }
                });

            migrationBuilder.InsertData(
                table: "ReligionMasters",
                columns: new[] { "ReligionId", "ReligionName" },
                values: new object[] { new Guid("08c6ab3b-97df-4959-8390-e676d35b8ceb"), "Hindu" });

            migrationBuilder.CreateIndex(
                name: "IX_CasteMasters_ReligionIdRef",
                table: "CasteMasters",
                column: "ReligionIdRef");

            migrationBuilder.CreateIndex(
                name: "IX_CityMasters_StateIdRef",
                table: "CityMasters",
                column: "StateIdRef");

            migrationBuilder.CreateIndex(
                name: "IX_Donations_CityMasterCityId",
                table: "Donations",
                column: "CityMasterCityId");

            migrationBuilder.CreateIndex(
                name: "IX_StateMasters_CountryIdRef",
                table: "StateMasters",
                column: "CountryIdRef");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminMasters");

            migrationBuilder.DropTable(
                name: "CasteMasters");

            migrationBuilder.DropTable(
                name: "Donations");

            migrationBuilder.DropTable(
                name: "GenderMasters");

            migrationBuilder.DropTable(
                name: "InterestStatusMasters");

            migrationBuilder.DropTable(
                name: "MaritialStatusMasters");

            migrationBuilder.DropTable(
                name: "ReligionMasters");

            migrationBuilder.DropTable(
                name: "CityMasters");

            migrationBuilder.DropTable(
                name: "StateMasters");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
