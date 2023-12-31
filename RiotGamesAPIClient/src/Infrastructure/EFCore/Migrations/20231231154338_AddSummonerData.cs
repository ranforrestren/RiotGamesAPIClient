using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RiotGamesAPIClient.Migrations
{
    /// <inheritdoc />
    public partial class AddSummonerData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlayerProfileIconId",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PlayerRiotAccountId",
                table: "Players",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PlayerSummonerId",
                table: "Players",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "PlayerSummonerLevel",
                table: "Players",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlayerProfileIconId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "PlayerRiotAccountId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "PlayerSummonerId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "PlayerSummonerLevel",
                table: "Players");
        }
    }
}
