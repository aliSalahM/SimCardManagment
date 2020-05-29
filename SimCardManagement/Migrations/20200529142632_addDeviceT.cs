using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimCardManagement.Migrations
{
    public partial class addDeviceT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Device",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Clan = table.Column<string>(nullable: true),
                    Birthdate = table.Column<DateTime>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    NearPoint = table.Column<string>(nullable: true),
                    Phone1 = table.Column<string>(nullable: true),
                    Phone2 = table.Column<string>(nullable: true),
                    Work = table.Column<string>(nullable: true),
                    IdCardNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    DeviceName = table.Column<string>(nullable: true),
                    UsageType = table.Column<string>(nullable: true),
                    IMEI = table.Column<string>(nullable: true),
                    SimCardId = table.Column<Guid>(nullable: false),
                    CarType = table.Column<string>(nullable: true),
                    CarColor = table.Column<string>(nullable: true),
                    CarNumber = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    SanaweiaNumber = table.Column<string>(nullable: true),
                    Vin = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Device", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Device_SimCard_SimCardId",
                        column: x => x.SimCardId,
                        principalTable: "SimCard",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Device_SimCardId",
                table: "Device",
                column: "SimCardId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Device");
        }
    }
}
