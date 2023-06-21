using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class Playlistupdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MergedPlaylistPlaylist");

            migrationBuilder.DropTable(
                name: "MergedPlaylists");

            migrationBuilder.AddColumn<string>(
                name: "MergedPlaylists",
                table: "Playlists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MergedPlaylists",
                table: "Playlists");

            migrationBuilder.CreateTable(
                name: "MergedPlaylists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpotifyId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MergedPlaylists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MergedPlaylists_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MergedPlaylistPlaylist",
                columns: table => new
                {
                    InnerPlaylistsId = table.Column<int>(type: "int", nullable: false),
                    MergedPlaylistsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MergedPlaylistPlaylist", x => new { x.InnerPlaylistsId, x.MergedPlaylistsId });
                    table.ForeignKey(
                        name: "FK_MergedPlaylistPlaylist_MergedPlaylists_MergedPlaylistsId",
                        column: x => x.MergedPlaylistsId,
                        principalTable: "MergedPlaylists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MergedPlaylistPlaylist_Playlists_InnerPlaylistsId",
                        column: x => x.InnerPlaylistsId,
                        principalTable: "Playlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MergedPlaylistPlaylist_MergedPlaylistsId",
                table: "MergedPlaylistPlaylist",
                column: "MergedPlaylistsId");

            migrationBuilder.CreateIndex(
                name: "IX_MergedPlaylists_UserId",
                table: "MergedPlaylists",
                column: "UserId");
        }
    }
}
