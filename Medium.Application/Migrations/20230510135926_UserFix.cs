using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medium.Application.Migrations
{
    public partial class UserFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Tags",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AppUserId1",
                table: "Tags",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Bio",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "AppUserAppUser",
                columns: table => new
                {
                    FollewersId = table.Column<int>(type: "int", nullable: false),
                    FollowingsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserAppUser", x => new { x.FollewersId, x.FollowingsId });
                    table.ForeignKey(
                        name: "FK_AppUserAppUser_AspNetUsers_FollewersId",
                        column: x => x.FollewersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserAppUser_AspNetUsers_FollowingsId",
                        column: x => x.FollowingsId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tags_AppUserId",
                table: "Tags",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_AppUserId1",
                table: "Tags",
                column: "AppUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserAppUser_FollowingsId",
                table: "AppUserAppUser",
                column: "FollowingsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_AspNetUsers_AppUserId",
                table: "Tags",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_AspNetUsers_AppUserId1",
                table: "Tags",
                column: "AppUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_AspNetUsers_AppUserId",
                table: "Tags");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_AspNetUsers_AppUserId1",
                table: "Tags");

            migrationBuilder.DropTable(
                name: "AppUserAppUser");

            migrationBuilder.DropIndex(
                name: "IX_Tags_AppUserId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_AppUserId1",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "AppUserId1",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "Bio",
                table: "AspNetUsers");
        }
    }
}
