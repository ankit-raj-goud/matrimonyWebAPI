using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MatrimonyWebApi.Migrations
{
    /// <inheritdoc />
    public partial class candiateTableAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidate_CasteMasters_CasteIdRef",
                table: "Candidate");

            migrationBuilder.DropForeignKey(
                name: "FK_Candidate_CityMasters_CityIdRef",
                table: "Candidate");

            migrationBuilder.DropForeignKey(
                name: "FK_Candidate_GenderMasters_GenderIdRef",
                table: "Candidate");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidateLoginDetails_Candidate_CandidateIdRef",
                table: "CandidateLoginDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Candidate",
                table: "Candidate");

            migrationBuilder.RenameTable(
                name: "Candidate",
                newName: "Candidates");

            migrationBuilder.RenameIndex(
                name: "IX_Candidate_GenderIdRef",
                table: "Candidates",
                newName: "IX_Candidates_GenderIdRef");

            migrationBuilder.RenameIndex(
                name: "IX_Candidate_CityIdRef",
                table: "Candidates",
                newName: "IX_Candidates_CityIdRef");

            migrationBuilder.RenameIndex(
                name: "IX_Candidate_CasteIdRef",
                table: "Candidates",
                newName: "IX_Candidates_CasteIdRef");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Candidates",
                table: "Candidates",
                column: "CandidateId");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateLoginDetails_Candidates_CandidateIdRef",
                table: "CandidateLoginDetails",
                column: "CandidateIdRef",
                principalTable: "Candidates",
                principalColumn: "CandidateId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_CasteMasters_CasteIdRef",
                table: "Candidates",
                column: "CasteIdRef",
                principalTable: "CasteMasters",
                principalColumn: "CasteId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_CityMasters_CityIdRef",
                table: "Candidates",
                column: "CityIdRef",
                principalTable: "CityMasters",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_GenderMasters_GenderIdRef",
                table: "Candidates",
                column: "GenderIdRef",
                principalTable: "GenderMasters",
                principalColumn: "GenderId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateLoginDetails_Candidates_CandidateIdRef",
                table: "CandidateLoginDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_CasteMasters_CasteIdRef",
                table: "Candidates");

            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_CityMasters_CityIdRef",
                table: "Candidates");

            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_GenderMasters_GenderIdRef",
                table: "Candidates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Candidates",
                table: "Candidates");

            migrationBuilder.RenameTable(
                name: "Candidates",
                newName: "Candidate");

            migrationBuilder.RenameIndex(
                name: "IX_Candidates_GenderIdRef",
                table: "Candidate",
                newName: "IX_Candidate_GenderIdRef");

            migrationBuilder.RenameIndex(
                name: "IX_Candidates_CityIdRef",
                table: "Candidate",
                newName: "IX_Candidate_CityIdRef");

            migrationBuilder.RenameIndex(
                name: "IX_Candidates_CasteIdRef",
                table: "Candidate",
                newName: "IX_Candidate_CasteIdRef");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Candidate",
                table: "Candidate",
                column: "CandidateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidate_CasteMasters_CasteIdRef",
                table: "Candidate",
                column: "CasteIdRef",
                principalTable: "CasteMasters",
                principalColumn: "CasteId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Candidate_CityMasters_CityIdRef",
                table: "Candidate",
                column: "CityIdRef",
                principalTable: "CityMasters",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Candidate_GenderMasters_GenderIdRef",
                table: "Candidate",
                column: "GenderIdRef",
                principalTable: "GenderMasters",
                principalColumn: "GenderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateLoginDetails_Candidate_CandidateIdRef",
                table: "CandidateLoginDetails",
                column: "CandidateIdRef",
                principalTable: "Candidate",
                principalColumn: "CandidateId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
