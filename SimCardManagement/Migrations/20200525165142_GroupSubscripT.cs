using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimCardManagement.Migrations
{
    public partial class GroupSubscripT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FromDate",
                table: "Group");

            migrationBuilder.DropColumn(
                name: "Limit",
                table: "Group");

            migrationBuilder.DropColumn(
                name: "ToDate",
                table: "Group");

            migrationBuilder.CreateTable(
                name: "GroupSubscrip",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    GroupId = table.Column<Guid>(nullable: false),
                    FromDate = table.Column<DateTime>(nullable: false),
                    ToDate = table.Column<DateTime>(nullable: false),
                    Limit = table.Column<int>(nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupSubscrip", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupSubscrip_Group_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupSubscrip_GroupId",
                table: "GroupSubscrip",
                column: "GroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupSubscrip");

            migrationBuilder.AddColumn<DateTime>(
                name: "FromDate",
                table: "Group",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Limit",
                table: "Group",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ToDate",
                table: "Group",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
