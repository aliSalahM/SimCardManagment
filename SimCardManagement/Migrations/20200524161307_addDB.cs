using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimCardManagement.Migrations
{
    public partial class addDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Photo = table.Column<string>(nullable: true),
                    AccountType = table.Column<int>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    IdCardNumber = table.Column<string>(nullable: true),
                    WorkPostion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SimCard",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    SimCardNumber = table.Column<string>(nullable: true),
                    IMEI = table.Column<string>(nullable: true),
                    SimIP = table.Column<string>(nullable: true),
                    SimType = table.Column<string>(nullable: true),
                    Server = table.Column<string>(nullable: true),
                    ServerIp = table.Column<string>(nullable: true),
                    ServerLocation = table.Column<string>(nullable: true),
                    ServerLink = table.Column<string>(nullable: true),
                    ServerOS = table.Column<string>(nullable: true),
                    DevaiceName = table.Column<string>(nullable: true),
                    DeviceType = table.Column<string>(nullable: true),
                    DeviceModal = table.Column<string>(nullable: true),
                    DeviceLocation = table.Column<string>(nullable: true),
                    DeviceIMEI = table.Column<string>(nullable: true),
                    ACCT_CODE = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SimCard", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Limit = table.Column<int>(nullable: false),
                    BelongToId = table.Column<string>(nullable: true),
                    FromDate = table.Column<DateTime>(nullable: false),
                    ToDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Group_AspNetUsers_BelongToId",
                        column: x => x.BelongToId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CDR",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CONTRNO = table.Column<string>(nullable: true),
                    MSISDN = table.Column<string>(nullable: true),
                    SimCardId = table.Column<Guid>(nullable: false),
                    PREPAID_FLAG = table.Column<string>(nullable: true),
                    STATUS = table.Column<string>(nullable: true),
                    REASON = table.Column<string>(nullable: true),
                    TARIFF_PROFILE = table.Column<string>(nullable: true),
                    USAGE_STATE = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CDR", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CDR_SimCard_SimCardId",
                        column: x => x.SimCardId,
                        principalTable: "SimCard",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupSimCards",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    GroupId = table.Column<Guid>(nullable: false),
                    SimCardId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupSimCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupSimCards_Group_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupSimCards_SimCard_SimCardId",
                        column: x => x.SimCardId,
                        principalTable: "SimCard",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReportCDR",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    GroupId = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    CONTRNO = table.Column<string>(nullable: true),
                    ActiveUsed = table.Column<int>(nullable: false),
                    ActiveNotUsed = table.Column<int>(nullable: false),
                    SuspendUsed = table.Column<string>(nullable: true),
                    SuspendNotUsed = table.Column<string>(nullable: true),
                    DeactiveUsed = table.Column<string>(nullable: true),
                    DeactiveNotUsed = table.Column<string>(nullable: true),
                    MSISDN_TOTAL = table.Column<string>(nullable: true),
                    Data_Usage_KB = table.Column<string>(nullable: true),
                    Data_Usage_MB = table.Column<string>(nullable: true),
                    Data_Usage_GB = table.Column<string>(nullable: true),
                    Remaining_Quota_KB = table.Column<string>(nullable: true),
                    Remaining_Quota_MB = table.Column<string>(nullable: true),
                    Remaining_Quota_GB = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportCDR", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportCDR_Group_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CDR_Date",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CDR_ID = table.Column<Guid>(nullable: false),
                    CDRId = table.Column<Guid>(nullable: true),
                    Date = table.Column<string>(nullable: true),
                    Ammount = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CDR_Date", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CDR_Date_CDR_CDRId",
                        column: x => x.CDRId,
                        principalTable: "CDR",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CDR_SimCardId",
                table: "CDR",
                column: "SimCardId");

            migrationBuilder.CreateIndex(
                name: "IX_CDR_Date_CDRId",
                table: "CDR_Date",
                column: "CDRId");

            migrationBuilder.CreateIndex(
                name: "IX_Group_BelongToId",
                table: "Group",
                column: "BelongToId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupSimCards_GroupId",
                table: "GroupSimCards",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupSimCards_SimCardId",
                table: "GroupSimCards",
                column: "SimCardId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportCDR_GroupId",
                table: "ReportCDR",
                column: "GroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CDR_Date");

            migrationBuilder.DropTable(
                name: "GroupSimCards");

            migrationBuilder.DropTable(
                name: "ReportCDR");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "CDR");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropTable(
                name: "SimCard");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
