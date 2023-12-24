using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MatrimonyWebApi.Migrations
{
    /// <inheritdoc />
    public partial class seedReligionData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ReligionMasters",
                columns: new[] { "ReligionId", "ReligionName" },
                values: new object[] { new Guid("08c6ab3b-97df-4959-8390-e676d35b8ceb"), "Hindu" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ReligionMasters",
                keyColumn: "ReligionId",
                keyValue: new Guid("08c6ab3b-97df-4959-8390-e676d35b8ceb"));
        }
    }
}
