using Microsoft.EntityFrameworkCore.Migrations;

namespace SimCardManagement.Migrations
{
    public partial class GroupSubscripTEdit2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "GroupSubscrip",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "GroupSubscrip");
        }
    }
}
