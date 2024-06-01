using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YourTurnFriend.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSequence : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SEQUENCE_IN_EVENT",
                table: "YTF_MEMBER",
                type: "INTEGER",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SEQUENCE_IN_EVENT",
                table: "YTF_MEMBER");
        }
    }
}
