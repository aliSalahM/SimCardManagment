using Microsoft.EntityFrameworkCore.Migrations;

namespace SimCardManagement.Migrations
{
    public partial class GroupSubscripTEdit1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "GroupSubscrip");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "GroupSubscrip",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
