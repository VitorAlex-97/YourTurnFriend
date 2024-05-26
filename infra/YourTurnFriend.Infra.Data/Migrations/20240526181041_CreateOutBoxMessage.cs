using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YourTurnFriend.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateOutBoxMessage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "YTF_OUT_BOX_MESSAGE",
                columns: table => new
                {
                    ID = table.Column<string>(type: "TEXT", nullable: false),
                    TYPE = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    CONTENT = table.Column<string>(type: "TEXT", nullable: false),
                    OCURRED_ON = table.Column<string>(type: "TEXT", nullable: false),
                    PROCESSED_ON = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YTF_OUT_BOX_MESSAGE", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "YTF_OUT_BOX_MESSAGE");
        }
    }
}
