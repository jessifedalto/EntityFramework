using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseReadyToWorkWith : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChannelManagements_ChannelRoles_ChannelRoleId",
                table: "ChannelManagements");

            migrationBuilder.DropForeignKey(
                name: "FK_ChannelManagements_Channels_ChannelId",
                table: "ChannelManagements");

            migrationBuilder.DropForeignKey(
                name: "FK_ChannelManagements_Users_UserId",
                table: "ChannelManagements");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Videos_VideoId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Contents_Videos_VideoId",
                table: "Contents");

            migrationBuilder.DropForeignKey(
                name: "FK_Playlists_Users_UserId",
                table: "Playlists");

            migrationBuilder.DropForeignKey(
                name: "FK_Reactions_Users_UserId",
                table: "Reactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Reactions_Videos_VideoId",
                table: "Reactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscribeds_Channels_ChannelId",
                table: "Subscribeds");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscribeds_Users_UserId",
                table: "Subscribeds");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Videos_Channels_ChannelId",
                table: "Videos");

            migrationBuilder.AddColumn<string>(
                name: "ChannelPermissionName",
                table: "ChannelPermissions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ChannelManagements_ChannelRoles_ChannelRoleId",
                table: "ChannelManagements",
                column: "ChannelRoleId",
                principalTable: "ChannelRoles",
                principalColumn: "ChannelRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChannelManagements_Channels_ChannelId",
                table: "ChannelManagements",
                column: "ChannelId",
                principalTable: "Channels",
                principalColumn: "ChannelId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChannelManagements_Users_UserId",
                table: "ChannelManagements",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Videos_VideoId",
                table: "Comments",
                column: "VideoId",
                principalTable: "Videos",
                principalColumn: "VideoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contents_Videos_VideoId",
                table: "Contents",
                column: "VideoId",
                principalTable: "Videos",
                principalColumn: "VideoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Playlists_Users_UserId",
                table: "Playlists",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reactions_Users_UserId",
                table: "Reactions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reactions_Videos_VideoId",
                table: "Reactions",
                column: "VideoId",
                principalTable: "Videos",
                principalColumn: "VideoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscribeds_Channels_ChannelId",
                table: "Subscribeds",
                column: "ChannelId",
                principalTable: "Channels",
                principalColumn: "ChannelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscribeds_Users_UserId",
                table: "Subscribeds",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_Channels_ChannelId",
                table: "Videos",
                column: "ChannelId",
                principalTable: "Channels",
                principalColumn: "ChannelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChannelManagements_ChannelRoles_ChannelRoleId",
                table: "ChannelManagements");

            migrationBuilder.DropForeignKey(
                name: "FK_ChannelManagements_Channels_ChannelId",
                table: "ChannelManagements");

            migrationBuilder.DropForeignKey(
                name: "FK_ChannelManagements_Users_UserId",
                table: "ChannelManagements");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Videos_VideoId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Contents_Videos_VideoId",
                table: "Contents");

            migrationBuilder.DropForeignKey(
                name: "FK_Playlists_Users_UserId",
                table: "Playlists");

            migrationBuilder.DropForeignKey(
                name: "FK_Reactions_Users_UserId",
                table: "Reactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Reactions_Videos_VideoId",
                table: "Reactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscribeds_Channels_ChannelId",
                table: "Subscribeds");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscribeds_Users_UserId",
                table: "Subscribeds");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Videos_Channels_ChannelId",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "ChannelPermissionName",
                table: "ChannelPermissions");

            migrationBuilder.AddForeignKey(
                name: "FK_ChannelManagements_ChannelRoles_ChannelRoleId",
                table: "ChannelManagements",
                column: "ChannelRoleId",
                principalTable: "ChannelRoles",
                principalColumn: "ChannelRoleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChannelManagements_Channels_ChannelId",
                table: "ChannelManagements",
                column: "ChannelId",
                principalTable: "Channels",
                principalColumn: "ChannelId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChannelManagements_Users_UserId",
                table: "ChannelManagements",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Videos_VideoId",
                table: "Comments",
                column: "VideoId",
                principalTable: "Videos",
                principalColumn: "VideoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contents_Videos_VideoId",
                table: "Contents",
                column: "VideoId",
                principalTable: "Videos",
                principalColumn: "VideoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Playlists_Users_UserId",
                table: "Playlists",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reactions_Users_UserId",
                table: "Reactions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reactions_Videos_VideoId",
                table: "Reactions",
                column: "VideoId",
                principalTable: "Videos",
                principalColumn: "VideoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscribeds_Channels_ChannelId",
                table: "Subscribeds",
                column: "ChannelId",
                principalTable: "Channels",
                principalColumn: "ChannelId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscribeds_Users_UserId",
                table: "Subscribeds",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_Channels_ChannelId",
                table: "Videos",
                column: "ChannelId",
                principalTable: "Channels",
                principalColumn: "ChannelId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
