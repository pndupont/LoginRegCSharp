using Microsoft.EntityFrameworkCore.Migrations;

namespace LOGINREG.Migrations
{
    public partial class unmappedconfirmpw : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConfirmPassword",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConfirmPassword",
                table: "Users",
                nullable: false,
                defaultValue: "");
        }
    }
}
