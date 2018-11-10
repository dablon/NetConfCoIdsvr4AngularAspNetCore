using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Event.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FullName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkShops",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsFree = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkShops", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkshopUser",
                columns: table => new
                {
                    WorkshopId = table.Column<Guid>(nullable: false),
                    EventUserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkshopUser", x => new { x.WorkshopId, x.EventUserId });
                    table.ForeignKey(
                        name: "FK_WorkshopUser_EventUsers_EventUserId",
                        column: x => x.EventUserId,
                        principalTable: "EventUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkshopUser_WorkShops_WorkshopId",
                        column: x => x.WorkshopId,
                        principalTable: "WorkShops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkshopUser_EventUserId",
                table: "WorkshopUser",
                column: "EventUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkshopUser");

            migrationBuilder.DropTable(
                name: "EventUsers");

            migrationBuilder.DropTable(
                name: "WorkShops");
        }
    }
}
