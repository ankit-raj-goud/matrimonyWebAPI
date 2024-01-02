using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MatrimonyWebApi.Migrations
{
    /// <inheritdoc />
    public partial class CandidateMasterAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidate",
                columns: table => new
                {
                    CandidateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubCaste = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FatherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FamilyType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FamilyIncome = table.Column<double>(type: "float", nullable: false),
                    IsProfilePictureOpenVisible = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DesiredPartnerDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactPerson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsContactNumberOpen = table.Column<bool>(type: "bit", nullable: false),
                    Height = table.Column<float>(type: "real", nullable: false),
                    Weight = table.Column<float>(type: "real", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Profession = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonalMonthlyIncome = table.Column<double>(type: "float", nullable: false),
                    CityIdRef = table.Column<int>(type: "int", nullable: false),
                    CasteIdRef = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GenderIdRef = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidate", x => x.CandidateId);
                    table.ForeignKey(
                        name: "FK_Candidate_CasteMasters_CasteIdRef",
                        column: x => x.CasteIdRef,
                        principalTable: "CasteMasters",
                        principalColumn: "CasteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Candidate_CityMasters_CityIdRef",
                        column: x => x.CityIdRef,
                        principalTable: "CityMasters",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Candidate_GenderMasters_GenderIdRef",
                        column: x => x.GenderIdRef,
                        principalTable: "GenderMasters",
                        principalColumn: "GenderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CandidateLoginDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateIdRef = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateLoginDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidateLoginDetails_Candidate_CandidateIdRef",
                        column: x => x.CandidateIdRef,
                        principalTable: "Candidate",
                        principalColumn: "CandidateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Candidate_CasteIdRef",
                table: "Candidate",
                column: "CasteIdRef");

            migrationBuilder.CreateIndex(
                name: "IX_Candidate_CityIdRef",
                table: "Candidate",
                column: "CityIdRef");

            migrationBuilder.CreateIndex(
                name: "IX_Candidate_GenderIdRef",
                table: "Candidate",
                column: "GenderIdRef");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateLoginDetails_CandidateIdRef",
                table: "CandidateLoginDetails",
                column: "CandidateIdRef");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidateLoginDetails");

            migrationBuilder.DropTable(
                name: "Candidate");
        }
    }
}
