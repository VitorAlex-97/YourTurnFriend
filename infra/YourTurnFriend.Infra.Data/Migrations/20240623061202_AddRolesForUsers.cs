using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YourTurnFriend.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRolesForUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "YTF_ROLE",
                columns: table => new
                {
                    ID = table.Column<string>(type: "TEXT", nullable: false),
                    NAME = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YTF_ROLE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "YTF_USER_ROLE",
                columns: table => new
                {
                    RolesId = table.Column<string>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YTF_USER_ROLE", x => new { x.RolesId, x.UserId });
                    table.ForeignKey(
                        name: "FK_YTF_USER_ROLE_YTF_ROLE_RolesId",
                        column: x => x.RolesId,
                        principalTable: "YTF_ROLE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_YTF_USER_ROLE_YTF_USER_UserId",
                        column: x => x.UserId,
                        principalTable: "YTF_USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "YTF_ROLE",
                columns: new[] { "ID", "NAME" },
                values: new object[,]
                {
                    { "63b4e757-6e24-4507-8f47-9030b17d85bd", "ADMIN" },
                    { "f4706406-9ef9-4b13-a137-43d04a0ba009", "DEFAULT" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_YTF_ROLE_NAME",
                table: "YTF_ROLE",
                column: "NAME");

            migrationBuilder.CreateIndex(
                name: "IX_YTF_USER_ROLE_UserId",
                table: "YTF_USER_ROLE",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "YTF_USER_ROLE");

            migrationBuilder.DropTable(
                name: "YTF_ROLE");
        }
    }
}
