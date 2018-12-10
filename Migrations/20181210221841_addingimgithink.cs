using Microsoft.EntityFrameworkCore.Migrations;

namespace UpdatedDojoDatchi.Migrations
{
    public partial class addingimgithink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "img",
                table: "Monsters",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "img",
                table: "Monsters");
        }
    }
}
