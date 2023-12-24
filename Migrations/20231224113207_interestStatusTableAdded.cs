using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MatrimonyWebApi.Migrations
{
    /// <inheritdoc />
    public partial class interestStatusTableAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "InterestStatusMasters",
                columns: new[] { "InterestStatusId", "InterestStatus" },
                values: new object[,]
                {
                    { 1, "Open" },
                    { 2, "Accepted" },
                    { 3, "Rejected" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InterestStatusMasters");
        }
    }
}
