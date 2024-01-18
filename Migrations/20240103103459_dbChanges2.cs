using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MatrimonyWebApi.Migrations
{
    /// <inheritdoc />
    public partial class dbChanges2 : Migration
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
                name: "Candidates",
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
                    table.PrimaryKey("PK_Candidates", x => x.CandidateId);
                    table.ForeignKey(
                        name: "FK_Candidates_CasteMasters_CasteIdRef",
                        column: x => x.CasteIdRef,
                        principalTable: "CasteMasters",
                        principalColumn: "CasteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Candidates_CityMasters_CityIdRef",
                        column: x => x.CityIdRef,
                        principalTable: "CityMasters",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Candidates_GenderMasters_GenderIdRef",
                        column: x => x.GenderIdRef,
                        principalTable: "GenderMasters",
                        principalColumn: "GenderId",
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
                    CityIdRef = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donations", x => x.DonationId);
                    table.ForeignKey(
                        name: "FK_Donations_CityMasters_CityIdRef",
                        column: x => x.CityIdRef,
                        principalTable: "CityMasters",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CandidateLoginDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CandidateIdRef = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateLoginDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidateLoginDetails_Candidates_CandidateIdRef",
                        column: x => x.CandidateIdRef,
                        principalTable: "Candidates",
                        principalColumn: "CandidateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    InterestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderIdRef = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReceiverIdRef = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InterestStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interests", x => x.InterestId);
                    table.ForeignKey(
                        name: "FK_Interests_Candidates_ReceiverIdRef",
                        column: x => x.ReceiverIdRef,
                        principalTable: "Candidates",
                        principalColumn: "CandidateId");
                    table.ForeignKey(
                        name: "FK_Interests_Candidates_SenderIdRef",
                        column: x => x.SenderIdRef,
                        principalTable: "Candidates",
                        principalColumn: "CandidateId");
                    table.ForeignKey(
                        name: "FK_Interests_InterestStatusMasters_InterestStatusId",
                        column: x => x.InterestStatusId,
                        principalTable: "InterestStatusMasters",
                        principalColumn: "InterestStatusId",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_CandidateLoginDetails_CandidateIdRef",
                table: "CandidateLoginDetails",
                column: "CandidateIdRef");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_CasteIdRef",
                table: "Candidates",
                column: "CasteIdRef");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_CityIdRef",
                table: "Candidates",
                column: "CityIdRef");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_GenderIdRef",
                table: "Candidates",
                column: "GenderIdRef");

            migrationBuilder.CreateIndex(
                name: "IX_CasteMasters_ReligionIdRef",
                table: "CasteMasters",
                column: "ReligionIdRef");

            migrationBuilder.CreateIndex(
                name: "IX_CityMasters_StateIdRef",
                table: "CityMasters",
                column: "StateIdRef");

            migrationBuilder.CreateIndex(
                name: "IX_Donations_CityIdRef",
                table: "Donations",
                column: "CityIdRef");

            migrationBuilder.CreateIndex(
                name: "IX_Interests_InterestStatusId",
                table: "Interests",
                column: "InterestStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Interests_ReceiverIdRef",
                table: "Interests",
                column: "ReceiverIdRef");

            migrationBuilder.CreateIndex(
                name: "IX_Interests_SenderIdRef",
                table: "Interests",
                column: "SenderIdRef");

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
                name: "CandidateLoginDetails");

            migrationBuilder.DropTable(
                name: "Donations");

            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropTable(
                name: "MaritialStatusMasters");

            migrationBuilder.DropTable(
                name: "Candidates");

            migrationBuilder.DropTable(
                name: "InterestStatusMasters");

            migrationBuilder.DropTable(
                name: "CasteMasters");

            migrationBuilder.DropTable(
                name: "CityMasters");

            migrationBuilder.DropTable(
                name: "GenderMasters");

            migrationBuilder.DropTable(
                name: "ReligionMasters");

            migrationBuilder.DropTable(
                name: "StateMasters");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
