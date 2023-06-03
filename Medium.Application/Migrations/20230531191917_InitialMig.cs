using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medium.Application.Migrations
{
    public partial class InitialMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_AspNetUsers_OwnerId",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_OwnerId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "Private",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "Articles",
                newName: "Likes");

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Articles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AppUserId1",
                table: "Articles",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "34b690aa-55d0-456e-aced-f02628c1e7f7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "5669c972-ce56-4636-b1a3-ec45d7382db8");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_AppUserId",
                table: "Articles",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_AppUserId1",
                table: "Articles",
                column: "AppUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_AspNetUsers_AppUserId",
                table: "Articles",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_AspNetUsers_AppUserId1",
                table: "Articles",
                column: "AppUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_AspNetUsers_AppUserId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Articles_AspNetUsers_AppUserId1",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_AppUserId",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_AppUserId1",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "AppUserId1",
                table: "Articles");

            migrationBuilder.RenameColumn(
                name: "Likes",
                table: "Articles",
                newName: "OwnerId");

            migrationBuilder.AddColumn<bool>(
                name: "Private",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "AspNetUsers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "819f1d21-4d14-4e5b-ab80-5e4bf2c23bb1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "879b8fbf-d2bb-493d-a80b-8e92639c89b1");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_OwnerId",
                table: "Articles",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_AspNetUsers_OwnerId",
                table: "Articles",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
