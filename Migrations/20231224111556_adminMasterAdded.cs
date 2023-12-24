using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MatrimonyWebApi.Migrations
{
    /// <inheritdoc />
    public partial class adminMasterAdded : Migration
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

            migrationBuilder.InsertData(
                table: "AdminMasters",
                columns: new[] { "UserId", "Password", "UserName" },
                values: new object[] { new Guid("dd467971-80d6-43a6-a1ab-8b64cd25dedd"), "admin", "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminMasters");
        }
    }
}
