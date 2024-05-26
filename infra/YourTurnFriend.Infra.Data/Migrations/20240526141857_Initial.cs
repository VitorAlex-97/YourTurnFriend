using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YourTurnFriend.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "YTF_EVENT",
                columns: table => new
                {
                    ID = table.Column<string>(type: "TEXT", nullable: false),
                    TITLE = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    ID_OWNER = table.Column<string>(type: "TEXT", nullable: false),
                    DATE_NEXT_EVENT = table.Column<string>(type: "TEXT", nullable: false),
                    DATE_LAST_EVENT = table.Column<string>(type: "TEXT", nullable: true),
                    Frequence = table.Column<string>(type: "TEXT", nullable: false),
                    ID_NEXT_MEMBER_IN_TURN = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YTF_EVENT", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "YTF_USER",
                columns: table => new
                {
                    ID = table.Column<string>(type: "TEXT", nullable: false),
                    USERNAME = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    PASSWORD = table.Column<string>(type: "TEXT", maxLength: 8, nullable: false),
                    CREATED_AT = table.Column<string>(type: "TEXT", nullable: false),
                    LAST_UPDATED_AT = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YTF_USER", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "YTF_MEMBER",
                columns: table => new
                {
                    ID = table.Column<string>(type: "TEXT", nullable: false),
                    NAME = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    ID_EVENT = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YTF_MEMBER", x => x.ID);
                    table.ForeignKey(
                        name: "FK_YTF_MEMBER_YTF_EVENT_ID_EVENT",
                        column: x => x.ID_EVENT,
                        principalTable: "YTF_EVENT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_YTF_MEMBER_ID_EVENT",
                table: "YTF_MEMBER",
                column: "ID_EVENT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "YTF_MEMBER");

            migrationBuilder.DropTable(
                name: "YTF_USER");

            migrationBuilder.DropTable(
                name: "YTF_EVENT");
        }
    }
}
