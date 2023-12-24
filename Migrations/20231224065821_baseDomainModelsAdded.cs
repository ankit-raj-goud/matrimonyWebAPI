using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MatrimonyWebApi.Migrations
{
    /// <inheritdoc />
    public partial class baseDomainModelsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    CoutnryId = table.Column<int>(type: "int", nullable: false),
                    CountryCoutnryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateMasters", x => x.StateId);
                    table.ForeignKey(
                        name: "FK_StateMasters_Country_CountryCoutnryId",
                        column: x => x.CountryCoutnryId,
                        principalTable: "Country",
                        principalColumn: "CoutnryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CasteMasters",
                columns: table => new
                {
                    CasteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CasteName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReligionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReligionMasterReligionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CasteMasters", x => x.CasteId);
                    table.ForeignKey(
                        name: "FK_CasteMasters_ReligionMasters_ReligionMasterReligionId",
                        column: x => x.ReligionMasterReligionId,
                        principalTable: "ReligionMasters",
                        principalColumn: "ReligionId");
                });

            migrationBuilder.CreateTable(
                name: "CityMasters",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    StateMasterStateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityMasters", x => x.CityId);
                    table.ForeignKey(
                        name: "FK_CityMasters_StateMasters_StateMasterStateId",
                        column: x => x.StateMasterStateId,
                        principalTable: "StateMasters",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CasteMasters_ReligionMasterReligionId",
                table: "CasteMasters",
                column: "ReligionMasterReligionId");

            migrationBuilder.CreateIndex(
                name: "IX_CityMasters_StateMasterStateId",
                table: "CityMasters",
                column: "StateMasterStateId");

            migrationBuilder.CreateIndex(
                name: "IX_StateMasters_CountryCoutnryId",
                table: "StateMasters",
                column: "CountryCoutnryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CasteMasters");

            migrationBuilder.DropTable(
                name: "CityMasters");

            migrationBuilder.DropTable(
                name: "ReligionMasters");

            migrationBuilder.DropTable(
                name: "StateMasters");
        }
    }
}
