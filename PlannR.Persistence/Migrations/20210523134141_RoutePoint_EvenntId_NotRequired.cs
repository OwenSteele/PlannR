using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PlannR.Persistence.Migrations
{
    public partial class RoutePoint_EvenntId_NotRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoutePoints_Events_EventId",
                table: "RoutePoints");

            migrationBuilder.DropIndex(
                name: "IX_RoutePoints_EventId",
                table: "RoutePoints");

            migrationBuilder.AlterColumn<Guid>(
                name: "EventId",
                table: "RoutePoints",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_RoutePoints_EventId",
                table: "RoutePoints",
                column: "EventId",
                unique: true,
                filter: "[EventId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_RoutePoints_Events_EventId",
                table: "RoutePoints",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoutePoints_Events_EventId",
                table: "RoutePoints");

            migrationBuilder.DropIndex(
                name: "IX_RoutePoints_EventId",
                table: "RoutePoints");

            migrationBuilder.AlterColumn<Guid>(
                name: "EventId",
                table: "RoutePoints",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoutePoints_EventId",
                table: "RoutePoints",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoutePoints_Events_EventId",
                table: "RoutePoints",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
