using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CivilServantShredderApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BP_Polls",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CommunityId = table.Column<Guid>(type: "TEXT", nullable: false),
                    HeadLine = table.Column<string>(type: "TEXT", nullable: false),
                    Text = table.Column<string>(type: "TEXT", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PollSelections = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BP_Polls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BP_TextAndPictures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CommunityId = table.Column<Guid>(type: "TEXT", nullable: false),
                    HeadLine = table.Column<string>(type: "TEXT", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Text = table.Column<string>(type: "TEXT", nullable: true),
                    PictureBase64 = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BP_TextAndPictures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BP_TextOnlys",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CommunityId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Text = table.Column<string>(type: "TEXT", nullable: false),
                    HeadLine = table.Column<string>(type: "TEXT", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BP_TextOnlys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Communities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Communities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Street = table.Column<string>(type: "TEXT", nullable: false),
                    PostalCode = table.Column<string>(type: "TEXT", nullable: false),
                    Locality = table.Column<string>(type: "TEXT", nullable: false),
                    CommunityId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BP_Polls");

            migrationBuilder.DropTable(
                name: "BP_TextAndPictures");

            migrationBuilder.DropTable(
                name: "BP_TextOnlys");

            migrationBuilder.DropTable(
                name: "Communities");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
