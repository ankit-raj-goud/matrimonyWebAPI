using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MatrimonyWebApi.Migrations
{
    /// <inheritdoc />
    public partial class ProfilePictureColumAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PictureType",
                table: "CandidateProfilePictures",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PictureType",
                table: "CandidateProfilePictures");
        }
    }
}
