using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FusionBlazorExample.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "_Events",
                columns: table => new
                {
                    Uuid = table.Column<string>(type: "TEXT", nullable: false),
                    Version = table.Column<long>(type: "INTEGER", nullable: false),
                    LoggedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DelayUntil = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ValueJson = table.Column<string>(type: "TEXT", nullable: false),
                    State = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Events", x => x.Uuid);
                });

            migrationBuilder.CreateTable(
                name: "_Operations",
                columns: table => new
                {
                    Index = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Uuid = table.Column<string>(type: "TEXT", nullable: false),
                    HostId = table.Column<string>(type: "TEXT", nullable: false),
                    LoggedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CommandJson = table.Column<string>(type: "TEXT", nullable: false),
                    ItemsJson = table.Column<string>(type: "TEXT", nullable: true),
                    NestedOperations = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Operations", x => x.Index);
                });

            migrationBuilder.CreateTable(
                name: "_Sessions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    Version = table.Column<long>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastSeenAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IPAddress = table.Column<string>(type: "TEXT", nullable: false),
                    UserAgent = table.Column<string>(type: "TEXT", nullable: false),
                    AuthenticatedIdentity = table.Column<string>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    IsSignOutForced = table.Column<bool>(type: "INTEGER", nullable: false),
                    OptionsJson = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Sessions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Version = table.Column<long>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimsJson = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserIdentities",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    Secret = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserIdentities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserIdentities_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX__Events_DelayUntil",
                table: "_Events",
                column: "DelayUntil");

            migrationBuilder.CreateIndex(
                name: "IX__Events_State_DelayUntil",
                table: "_Events",
                columns: new[] { "State", "DelayUntil" });

            migrationBuilder.CreateIndex(
                name: "IX__Operations_LoggedAt",
                table: "_Operations",
                column: "LoggedAt");

            migrationBuilder.CreateIndex(
                name: "IX__Operations_Uuid",
                table: "_Operations",
                column: "Uuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX__Sessions_CreatedAt_IsSignOutForced",
                table: "_Sessions",
                columns: new[] { "CreatedAt", "IsSignOutForced" });

            migrationBuilder.CreateIndex(
                name: "IX__Sessions_IPAddress_IsSignOutForced",
                table: "_Sessions",
                columns: new[] { "IPAddress", "IsSignOutForced" });

            migrationBuilder.CreateIndex(
                name: "IX__Sessions_LastSeenAt_IsSignOutForced",
                table: "_Sessions",
                columns: new[] { "LastSeenAt", "IsSignOutForced" });

            migrationBuilder.CreateIndex(
                name: "IX__Sessions_UserId_IsSignOutForced",
                table: "_Sessions",
                columns: new[] { "UserId", "IsSignOutForced" });

            migrationBuilder.CreateIndex(
                name: "IX_UserIdentities_Id",
                table: "UserIdentities",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserIdentities_UserId",
                table: "UserIdentities",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Name",
                table: "Users",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "_Events");

            migrationBuilder.DropTable(
                name: "_Operations");

            migrationBuilder.DropTable(
                name: "_Sessions");

            migrationBuilder.DropTable(
                name: "UserIdentities");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
