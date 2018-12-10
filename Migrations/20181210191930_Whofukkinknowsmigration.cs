using Microsoft.EntityFrameworkCore.Migrations;

namespace UpdatedDojoDatchi.Migrations
{
    public partial class Whofukkinknowsmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Monsters_MonsterObjectId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_MonsterObjectId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "MonsterObjectId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Monsters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Monsters_UserId",
                table: "Monsters",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Monsters_Users_UserId",
                table: "Monsters",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Monsters_Users_UserId",
                table: "Monsters");

            migrationBuilder.DropIndex(
                name: "IX_Monsters_UserId",
                table: "Monsters");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Monsters");

            migrationBuilder.AddColumn<int>(
                name: "MonsterObjectId",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_MonsterObjectId",
                table: "Users",
                column: "MonsterObjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Monsters_MonsterObjectId",
                table: "Users",
                column: "MonsterObjectId",
                principalTable: "Monsters",
                principalColumn: "MonsterObjectId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
