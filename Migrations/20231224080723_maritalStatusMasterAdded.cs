using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MatrimonyWebApi.Migrations
{
    /// <inheritdoc />
    public partial class maritalStatusMasterAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "MaritialStatusMasters",
                columns: new[] { "MaritialStatusId", "MaritialStatus" },
                values: new object[,]
                {
                    { 1, "Unmarried" },
                    { 2, "Widow" },
                    { 3, "Divorced" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaritialStatusMasters");
        }
    }
}
